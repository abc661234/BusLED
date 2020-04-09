'==========================================
' Title:  公車站名播報模擬
' Author: Petrix Huang
' Date:   2020/03/30
'==========================================

Imports System.IO
Public Class Start
    Public BusStop As Integer = 0
    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Dim sw As StreamWriter = New StreamWriter(".\Resource\info.txt")
        sw.WriteLine(BusStop)
        sw.WriteLine(ComboBox1.SelectedItem)
        Dim str As String
        For i = 1 To BusStop
            str = "TextBox" + (i * 2 - 1).ToString()
            sw.WriteLine(Me.Controls(str).Text)
            str = "TextBox" + (i * 2).ToString()
            sw.WriteLine(Me.Controls(str).Text)
            str = "Label" + (i * 4).ToString()
            sw.WriteLine(Me.Controls(str).Text)
        Next
        sw.Close()
        System.Diagnostics.Process.Start(".\Unity\BusLED.exe")
    End Sub

    Private Sub Button200_Click(sender As Object, e As EventArgs) Handles Button200.Click
        'Dim sw As StreamWriter = New StreamWriter(".\Resource\info.txt")
        'sw.WriteLine("6")
        'sw.WriteLine(ComboBox1.SelectedItem)
        'If ComboBox1.SelectedItem.ToString.Substring(3, 2) = "下一" Then
        '    sw.WriteLine("捷運動物園站")
        '    sw.WriteLine("MRT Taipei Zoo Station")
        '    sw.WriteLine(Application.StartupPath + "\Resource\捷運動物園站.wav")
        '    sw.WriteLine("貓纜動物園站")
        '    sw.WriteLine("Maokong Gondola Taipei Zoo Station")
        '    sw.WriteLine(Application.StartupPath + "\Resource\貓纜動物園站.wav")
        '    sw.WriteLine("萬壽橋頭(新光)")
        '    sw.WriteLine("Wanshou Bridge(Xinguang)")
        '    sw.WriteLine(Application.StartupPath + "\Resource\萬壽橋頭(新光).wav")
        '    sw.WriteLine("萬壽橋頭(秀明)")
        '    sw.WriteLine("Wanshou Qiaotou")
        '    sw.WriteLine(Application.StartupPath + "\Resource\萬壽橋頭(秀明).wav")
        '    sw.WriteLine("萬興國小")
        '    sw.WriteLine("Wanxing Elementary School")
        '    sw.WriteLine(Application.StartupPath + "\Resource\萬興國小.wav")
        '    sw.WriteLine("政大一")
        '    sw.WriteLine("National Chengchi University 1")
        '    sw.WriteLine(Application.StartupPath + "\Resource\政大一.wav")
        'Else
        '    sw.WriteLine("市府轉運站")
        '    sw.WriteLine("Taipei City Hall Bus Station")
        '    sw.WriteLine(Application.StartupPath + "\Resource\市府轉運站.wav")
        '    sw.WriteLine("君悅飯店")
        '    sw.WriteLine("Grand Hyatt Taipei")
        '    sw.WriteLine(Application.StartupPath + "\Resource\君悅飯店.wav")
        '    sw.WriteLine("遠東國際飯店")
        '    sw.WriteLine("Far Eastern Plaza Hotel")
        '    sw.WriteLine(Application.StartupPath + "\Resource\遠東國際飯店.wav")
        '    sw.WriteLine("福華飯店")
        '    sw.WriteLine("Howard Plaza")
        '    sw.WriteLine(Application.StartupPath + "\Resource\福華飯店.wav")
        '    sw.WriteLine("機場旅館")
        '    sw.WriteLine("Airport Hotel")
        '    sw.WriteLine(Application.StartupPath + "\Resource\機場旅館.wav")
        '    sw.WriteLine("臺灣桃園國際機場")
        '    sw.WriteLine("Taiwan Taoyuan International Airport")
        '    sw.WriteLine(Application.StartupPath + "\Resource\臺灣桃園國際機場.wav")
        'End If
        'sw.Close()
        'System.Diagnostics.Process.Start(".\Unity\BusLED.exe")
    End Sub

    Private Sub Label500_Click(sender As Object, e As EventArgs) Handles Label500.Click
        Label500.Top += 150
        Label600.Top += 150
        AddStop()
        If BusStop > 1 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub

    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddStop()
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
    End Sub

    Sub AddStop()
        Me.AutoScroll = False
        BusStop += 1
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            Dim lb As Label = New Label
            lb.Name = "Label" + (i + 1).ToString()
            If i Mod 4 = 0 Then
                lb.Text = "中文："
            ElseIf i Mod 4 = 1 Then
                lb.Text = "英文："
            ElseIf i Mod 4 = 2 Then
                lb.Text = "音檔："
            End If
            If i Mod 4 <> 3 Then
                lb.Location = New Point(35, (i + 1) * 50 - (BusStop - 1) * 50)
            Else
                lb.Location = New Point(242, i * 50 - (BusStop - 1) * 50 - 4)
                lb.Size = New Size(500, 100)
                lb.Font = New Font(Font.FontFamily, 12, FontStyle.Regular)
            End If
            Me.Controls.Add(lb)
            lb.BringToFront()
        Next
        For i = (BusStop - 1) * 2 To (BusStop - 1) * 2 + 1
            Dim tb As TextBox = New TextBox
            tb.Name = "TextBox" + (i + 1).ToString()
            tb.Location = New Point(130, 46 + i * 50 + (BusStop - 1) * 50)
            tb.Size = New Size(266, 35)
            If i Mod 2 = 1 Then
                tb.ImeMode = ImeMode.Off
            End If
            Me.Controls.Add(tb)
            tb.BringToFront()
        Next
        Dim bt As Button = New Button
        bt.Name = "Button" + BusStop.ToString()
        bt.Location = New Point(130, 46 + (BusStop + 1) * 50 + (BusStop - 1) * 100)
        bt.Text = "選擇檔案"
        bt.Size = New Size(107, 35)
        Me.Controls.Add(bt)
        bt.BringToFront()
        AddHandler bt.Click, AddressOf ChooseFile
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 100000)
    End Sub

    Public Sub ChooseFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim type As String = OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.Length - 3, 3)
            If type = "WAV" Or type = "wav" Then
                Dim LabelName As String
                Try
                    LabelName = "label" + (sender.name.ToString().Substring(6, 2) * 4).ToString()
                Catch
                    LabelName = "label" + (sender.name.ToString().Substring(6, 1) * 4).ToString()
                End Try
                Me.Controls(LabelName).Text = OpenFileDialog1.FileName
            Else
                MessageBox.Show("僅支援 WAV 檔", "不支援的檔案格式", 0, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Label600_Click(sender As Object, e As EventArgs) Handles Label600.Click
        Label500.Top -= 150
        Label600.Top -= 150
        Me.AutoScroll = False
        Dim rm As Control
        Me.AutoScroll = False
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            rm = Me.Controls("Label" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        For i = (BusStop - 1) * 2 To (BusStop - 1) * 2 + 1
            rm = Me.Controls("TextBox" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        rm = Me.Controls("Button" + BusStop.ToString())
        Me.Controls.Remove(rm)
        BusStop -= 1
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 100000)
        If BusStop > 1 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub
End Class
