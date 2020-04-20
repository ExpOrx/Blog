DELIMITER $$
CREATE DEFINER=`root`@`localhost` FUNCTION `is_online`(`tm` TIMESTAMP) RETURNS tinyint(4)
    NO SQL
    DETERMINISTIC
BEGIN
DECLARE res TINYINT;
IF `tm` > date_sub(now(), interval 24 hour) THEN SET res = 1;
ELSE SET res = 0;
END IF;
RETURN res;
END$$

DELIMITER ;


-- Example:
--SELECT timestamp, 
--CASE WHEN timestamp > date_sub(now(), interval 24 hour) THEN 1 ELSE 0 END AS is_online
--FROM `bots` 
