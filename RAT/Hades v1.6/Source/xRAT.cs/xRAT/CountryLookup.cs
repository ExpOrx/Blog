namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Net;

    public class CountryLookup
    {
        public MemoryStream _MemoryStream;
        private static long long_0;
        private static string[] string_0;
        private static string[] string_1;

        static CountryLookup()
        {
            Class1.QaIGh5M7cuigS();
            long_0 = 0xffff00L;
            string_0 = new string[] { 
                "N/A", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", 
                "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam", "Bolivia", "Brazil", 
                "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands", "Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", 
                "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", 
                "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "France, Metropolitan", "Gabon", "United Kingdom", "Grenada", "Georgia", 
                "French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", 
                "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica", "Jordan", "Japan", 
                "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Cayman Islands", "Kazakstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", 
                "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libyan Arab Jamahiriya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia, the Former Yugoslav Republic of", "Mali", "Myanmar", "Mongolia", "Macao", 
                "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", 
                "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", 
                "Pitcairn", "Puerto Rico", "Palestinian Territory, Occupied", "Portugal", "Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", 
                "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", 
                "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan, Province of China", "Tanzania, United Republic of", "Ukraine", "Uganda", 
                "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines", "Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Yugoslavia", 
                "South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man", "Jersey", "Saint Barthelemy", "Saint Martin"
             };
            string_1 = new string[] { 
                "--", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AN", "AO", "AQ", "AR", "AS", "AT", 
                "AU", "AW", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", 
                "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", 
                "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", 
                "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "FX", "GA", "GB", "GD", "GE", 
                "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", 
                "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM", "JO", "JP", 
                "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", 
                "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO", 
                "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", 
                "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", 
                "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC", "SD", "SE", 
                "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", 
                "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", 
                "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "RS", 
                "ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM", "JE", "BL", "MF"
             };
        }

        public CountryLookup(MemoryStream ms)
        {
            Class1.QaIGh5M7cuigS();
            this._MemoryStream = ms;
        }

        public CountryLookup(string FileLocation)
        {
            Class1.QaIGh5M7cuigS();
            FileStream stream = new FileStream(FileLocation, FileMode.Open, FileAccess.Read);
            this._MemoryStream = new MemoryStream();
            byte[] array = new byte[0x101];
            while (stream.Read(array, 0, array.Length) != 0)
            {
                this._MemoryStream.Write(array, 0, array.Length);
            }
            stream.Close();
        }

        public static MemoryStream FileToMemory(string FileLocation)
        {
            FileStream stream = new FileStream(FileLocation, FileMode.Open, FileAccess.Read);
            MemoryStream stream2 = new MemoryStream();
            byte[] array = new byte[0x101];
            while (stream.Read(array, 0, array.Length) != 0)
            {
                stream2.Write(array, 0, array.Length);
            }
            stream.Close();
            return stream2;
        }

        public string LookupCountryCode(IPAddress _IPAddress)
        {
            return string_1[(int) this.method_4(0L, this.method_0(_IPAddress), 0x1f)];
        }

        public string LookupCountryCode(string _IPAddress)
        {
            string str;
            try
            {
                IPAddress address = IPAddress.Parse(_IPAddress);
                return this.LookupCountryCode(address);
            }
            catch (FormatException exception1)
            {
                ProjectData.SetProjectError(exception1);
                str = "--";
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public string LookupCountryName(IPAddress addr)
        {
            return string_0[(int) this.method_4(0L, this.method_0(addr), 0x1f)];
        }

        public string LookupCountryName(string _IPAddress)
        {
            string str;
            try
            {
                IPAddress addr = IPAddress.Parse(_IPAddress);
                return this.LookupCountryName(addr);
            }
            catch (FormatException exception1)
            {
                ProjectData.SetProjectError(exception1);
                str = "N/A";
                ProjectData.ClearProjectError();
            }
            return str;
        }

        private long method_0(IPAddress ipaddress_0)
        {
            string[] array = Strings.Split(ipaddress_0.ToString(), ".", -1, CompareMethod.Binary);
            if (Information.UBound(array, 1) == 3)
            {
                return (long) Math.Round((double) ((((16777216.0 * Conversions.ToDouble(array[0])) + (65536.0 * Conversions.ToDouble(array[1]))) + (256.0 * Conversions.ToDouble(array[2]))) + Conversions.ToDouble(array[3])));
            }
            return 0L;
        }

        private string method_1(long long_1)
        {
            string str = Conversions.ToString((double) (Conversion.Int((double) (((double) long_1) / 16777216.0)) % 256.0));
            string str2 = Conversions.ToString((double) (Conversion.Int((double) (((double) long_1) / 65536.0)) % 256.0));
            string str3 = Conversions.ToString((double) (Conversion.Int((double) (((double) long_1) / 256.0)) % 256.0));
            string str4 = Conversions.ToString((long) (Conversion.Int(long_1) % 0x100L));
            return (str + "." + str2 + "." + str3 + "." + str4);
        }

        private long method_2(long long_1, int int_0)
        {
            long num = long_1;
            int num2 = int_0;
            for (int i = 1; i <= num2; i++)
            {
                num *= 2L;
            }
            return num;
        }

        private long method_3(long long_1, int int_0)
        {
            long num = long_1;
            int num2 = int_0;
            for (int i = 1; i <= num2; i++)
            {
                num /= 2L;
            }
            return num;
        }

        private long method_4(long long_1, long long_2, int int_0)
        {
            int num;
            byte[] buffer = new byte[7];
            long[] numArray = new long[3];
            if (int_0 == 0)
            {
            }
            try
            {
                this._MemoryStream.Seek(6L * long_1, SeekOrigin.Begin);
                this._MemoryStream.Read(buffer, 0, 6);
            }
            catch (IOException exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            int index = 0;
        Label_0092:
            numArray[index] = 0L;
            int num3 = 0;
        Label_007B:
            num = buffer[(index * 3) + num3];
            if (num < 0)
            {
                num += 0x100;
            }
            long[] numArray2 = numArray;
            int num4 = index;
            numArray2[num4] += this.method_2((long) num, num3 * 8);
            num3++;
            if (num3 > 2)
            {
                index++;
                if (index > 1)
                {
                    if ((long_2 & this.method_2(1L, int_0)) > 0L)
                    {
                        if (numArray[1] >= long_0)
                        {
                            return (numArray[1] - long_0);
                        }
                        return this.method_4(numArray[1], long_2, int_0 - 1);
                    }
                    if (numArray[0] >= long_0)
                    {
                        return (numArray[0] - long_0);
                    }
                    return this.method_4(numArray[0], long_2, int_0 - 1);
                }
            }
            else
            {
                goto Label_007B;
            }
            goto Label_0092;
        }
    }
}

