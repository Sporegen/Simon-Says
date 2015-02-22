Imports System.Windows.Media.Animation
Class MainWindow

    Private _series As New List(Of String)
    Private _sequence As New List(Of Storyboard)
    Private _index As Integer = 0
    Private _rnd As New Random
    Private WithEvents _timeline As New Storyboard

    Private Sub Button_MouseDown(sender As HexButton, e As MouseButtonEventArgs) Handles redButton.MouseDown, blueButton.MouseDown, yellowButton.MouseDown, greenButton.MouseDown
        If sender.Name = _series(_index) Then
            _index += 1
        Else
            MessageBox.Show("Helaas")
        End If

        If _index >= _series.Count Then
            addRandom()
            beginSeries()
        End If
    End Sub

    Private Sub addRandom()
        Select Case _rnd.Next(0, 3)
            Case 0
                _sequence.Add(FindResource("FlashBlue"))
                _series.Add("blueButton")
            Case 1
                _sequence.Add(FindResource("FlashRed"))
                _series.Add("redButton")
            Case 2
                _sequence.Add(FindResource("FlashGreen"))
                _series.Add("greenButton")
            Case 3
                _sequence.Add(FindResource("FlashYellow"))
                _series.Add("yellowButton")
            Case Else : Throw New Exception("Fout in willekeurigheid")
        End Select
    End Sub

    Private Sub beginSeries()
        _index = 0
        _timeline = _sequence(0)
        blueButton.IsEnabled = False
        redButton.IsEnabled = False
        greenButton.IsEnabled = False
        yellowButton.IsEnabled = False
        _timeline.Begin()
    End Sub

    Private Sub timeline_Completed() Handles _timeline.Completed
        If _index >= _series.Count - 1 Then
            _index = 0
            blueButton.IsEnabled = True
            redButton.IsEnabled = True
            greenButton.IsEnabled = True
            yellowButton.IsEnabled = True
        Else
            _index += 1
            _timeline = _sequence(_index)
            _timeline.Begin()


        End If
    End Sub


    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        For i As Integer = 0 To 1
            addRandom()
        Next
        beginSeries()
    End Sub
End Class
