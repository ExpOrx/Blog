
<?php
/**
 * AesCipher
 *
 * Encode/Decode text by password using AES-128-CBC algorithm
 */
class AesCipher
{
    const CIPHER = 'AES-128-CBC';
    const INIT_VECTOR_LENGTH = 16;
    /**
     * Encoded/Decoded data
     *
     * @var null|string
     */
    protected $data;
    /**
     * Initialization vector value
     *
     * @var string
     */
    protected $initVector;
    /**
     * Error message if operation failed
     *
     * @var null|string
     */
    protected $errorMessage;
    /**
     * AesCipher constructor.
     *
     * @param string $initVector        Initialization vector value
     * @param string|null $data         Encoded/Decoded data
     * @param string|null $errorMessage Error message if operation failed
     */
    public function __construct($initVector, $data = null, $errorMessage = null)
    {
        $this->initVector = $initVector;
        $this->data = $data;
        $this->errorMessage = $errorMessage;
    }
    /**
     * Encrypt input text by AES-128-CBC algorithm
     *
     * @param string $secretKey 16/24/32 -characters secret password
     * @param string $plainText Text for encryption
     *
     * @return self Self object instance with data or error message
     */
    public static function encrypt($secretKey, $plainText)
    {
        try {
            // Check secret length
            if (!static::isKeyLengthValid($secretKey)) {
                throw new \InvalidArgumentException("Secret key's length must be 128, 192 or 256 bits");
            }
            // Get random initialization vector
            $initVector = bin2hex(openssl_random_pseudo_bytes(static::INIT_VECTOR_LENGTH / 2));
            // Encrypt input text
            $raw = openssl_encrypt(
                $plainText,
                static::CIPHER,
                $secretKey,
                OPENSSL_RAW_DATA,
                $initVector
            );
            // Return base64-encoded string: initVector + encrypted result
            $result = base64_encode($initVector . $raw);
            if ($result === false) {
                // Operation failed
                return new static($initVector, null, openssl_error_string());
            }
            // Return successful encoded object
            return new static($initVector, $result);
        } catch (\Exception $e) {
            // Operation failed
            return new static(isset($initVector), null, $e->getMessage());
        }
    }
    /**
     * Decrypt encoded text by AES-128-CBC algorithm
     *
     * @param string $secretKey  16/24/32 -characters secret password
     * @param string $cipherText Encrypted text
     *
     * @return self Self object instance with data or error message
     */
    public static function decrypt($secretKey, $cipherText)
    {
        try {
            // Check secret length
            if (!static::isKeyLengthValid($secretKey)) {
                throw new \InvalidArgumentException("Secret key's length must be 128, 192 or 256 bits");
            }
            // Get raw encoded data
            $encoded = base64_decode($cipherText);
            // Slice initialization vector
            $initVector = substr($encoded, 0, static::INIT_VECTOR_LENGTH);
            // Slice encoded data
            $data = substr($encoded, static::INIT_VECTOR_LENGTH);
            // Trying to get decrypted text
            $decoded = openssl_decrypt(
                $data,
                static::CIPHER,
                $secretKey,
                OPENSSL_RAW_DATA,
                $initVector
            );
            if ($decoded === false) {
                // Operation failed
                return new static(isset($initVector), null, openssl_error_string());
            }
            // Return successful decoded object
            return new static($initVector, $decoded);
        } catch (\Exception $e) {
            // Operation failed
            return new static(isset($initVector), null, $e->getMessage());
        }
    }
    /**
     * Check that secret password length is valid
     *
     * @param string $secretKey 16/24/32 -characters secret password
     *
     * @return bool
     */
    public static function isKeyLengthValid($secretKey)
    {
        $length = strlen($secretKey);
        return $length == 16 || $length == 24 || $length == 32;
    }
    /**
     * Get encoded/decoded data
     *
     * @return string|null
     */
    public function getData()
    {
        return $this->data;
    }
    /**
     * Get initialization vector value
     *
     * @return string|null
     */
    public function getInitVector()
    {
        return $this->initVector;
    }
    /**
     * Get error message
     *
     * @return string|null
     */
    public function getErrorMessage()
    {
        return $this->errorMessage;
    }
    /**
     * Check that operation failed
     *
     * @return bool
     */
    public function hasError()
    {
        return $this->errorMessage !== null;
    }
    /**
     * To string return resulting data
     *
     * @return null|string
     */
    public function __toString()
    {
        return $this->getData();
    }
}
// USAGE
/*$secretKey = '26kozQaKwRuNJ24t';
$text = 'OMG!!! IT WORKS!!!!111';

RjQ0QkVCMkYwQTM0NDQ3M/aleC1It6sNvRgNdele2hi5cx5yyNEw62+KQXg0FW0zLC4NfB78WZgH
QUVGQ0MzREEwMkYxMUQ4OK4ZRgEjCv6nTp/cnpTI1h/NM4hPse/QhaBe2VJ1GfkCrvUW9EWfU4aG9cQqOKsedRGbVDZJdeQXO0qVaAu0js7Df+ClCqT1cvuQ4Ju1g2VpT+vtidv6AvWmYDmOQ171xojrwOYHKQGojOU0POgWyU/PUYMoVS5bxkcb/el+2zFt6UxxqexBI1uLJBO1vt9fNZkfLySnjLJZua/gwMIySM0AWjghUEvuNHbBEiS5O0oA8f+dVgin/+Z+ycw+gRo6SA==


$secretText = 'OUEwNjc0N0ZBRjM3MkFFN1IYs7uXUQ/Ebl+Br9Xsuyg=';

$secretKey = 'R{GH4YgE,MgjWCy6';
$secretText = 'NjI0ODYzRjdDNDU3MjZBMQlkqKXns7Oq2Y7GhLyl4nj85ljLY3ae6SeLWqP7Y4kLOdTIl2dzLMhyRP7JdOz/EaVzU/raLbvCmJIlC2NffITK+AXwbwDep9+xPDrUTT4fZ7xOp1Rs9D1rTuHgYlzZDQ==';


//$encrypted = AesCipher::encrypt($secretKey, $text);
//$decrypted = AesCipher::decrypt($secretKey, $encrypted);
$decryptedSecret = AesCipher::decrypt($secretKey, $secretText);

//echo $text;
//echo " encrypted: ".$encrypted;
echo " decrypted: ".$decryptedSecret->getData();
echo "<br><br>";
echo $decryptedSecret;
$encrypted->hasError(); // TRUE if operation failed, FALSE otherwise
$encrypted->getData(); // Encoded/Decoded result
$encrypted->getInitVector(); // Get used (random if encode) init vector*/
// $decrypted->* has identical methods