Public Class Class1
    ' 2 فنشكن ، واحدة للأرسال وواحدة للأستقبال
    Function Send(ByVal input As String) ' هاي اللي راح نستقبل عليها البيانات من القيمة True 
        ' لجل نرسلها
        If input = "ReProList" Then ' مثال توضيحي فقط لجل لو عندنا اكثر من امر للتحديث كعمليات وفايل مانجر و و وو .. إلخ
            Dim PL As String = String.Empty
            For Each Pro In Process.GetProcesses()
                Try
                    PL += Pro.ProcessName & "|" & Pro.Id & "|"
                Catch ex As Exception
                    PL += "????" & "|" & "????" & "|" ' تعود ههه
                End Try
            Next
            ' نسوي ريتيرن للقيمة
            Return PL
        End If
    End Function
    Function Receive(ByVal Input)
        ' نسوي سبلت للبيانات ونشوف ايش راح نسوي لو كان عندنا بيانات اكثر
        Dim Spl As String() = Split(Input, "|")
        If Spl(0) = "Kill" Then
            For Each P In Process.GetProcesses()
                If P.Id = Spl(1) Then
                    P.Kill()
                    Exit For
                End If
            Next
        End If
    End Function
End Class
