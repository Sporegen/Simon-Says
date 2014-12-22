Imports System.Windows.Media.Animation
Class MainWindow

    Private WithEvents game As New Game
    Private WithEvents timeline As New Storyboard
    Private Animations As New List(Of Storyboard)
    Private flashIndex As Integer = 1

    Private _score As Integer
    Public ReadOnly Property Score() As Integer
        Get
            Return _score
        End Get
    End Property


    Private Sub fillAnimationList()
        Animations.Clear()
        For Each element As String In game.Serie
            Select Case element
                Case "blueButton" : timeline = FindResource("flashBlue")
                Case "yellowButton" : timeline = FindResource("flashYellow")
                Case "greenButton" : timeline = FindResource("flashGreen")
                Case "redButton" : timeline = FindResource("flashRed")
            End Select
            Animations.Add(timeline)
        Next
    End Sub

    Private Sub flashSerie()
        fillAnimationList()
        timeline = Animations(0)
        blueButton.IsEnabled = False
        redButton.IsEnabled = False
        greenButton.IsEnabled = False
        yellowButton.IsEnabled = False
        timeline.Begin()
    End Sub

    Private Sub animation_Complete() Handles timeline.Completed
        If flashIndex >= game.Serie.Count Then
            flashIndex = 1
            blueButton.IsEnabled = True
            redButton.IsEnabled = True
            greenButton.IsEnabled = True
            yellowButton.IsEnabled = True
        Else

            timeline = Animations(flashIndex)
            timeline.Begin()
            flashIndex += 1
        End If
    End Sub

    Private Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click
        game.startGame()
        flashSerie()
        startButton.Visibility = Windows.Visibility.Collapsed
    End Sub

    Private Sub game_PositionReset() Handles game.PositionReset
        flashSerie()
    End Sub

    Private Sub button_Click(sender As Button, e As RoutedEventArgs) Handles redButton.Click, blueButton.Click, greenButton.Click, yellowButton.Click
        If Not game.checkButton(sender.Name) Then
            My.Computer.Audio.Play(My.Resources.Hyper_Distorted_Sad_Violin_Sound_Effect, AudioPlayMode.BackgroundLoop)
            MessageBox.Show("SCrublord", "Illumintai", MessageBoxButton.OK)
            MessageBox.Show("but what if messagebox is not kill?", "llominati", MessageBoxButton.OK)
            My.Computer.Audio.Play(My.Resources.The_X_Files_Theme, AudioPlayMode.BackgroundLoop)
            For i As Integer = 1 To 50
                MessageBox.Show("messagebox = illuminati", "fggt", MessageBoxButton.OK)
            Next
            MessageBox.Show("k ill stop", "fggt", MessageBoxButton.OK)
            Application.Current.Shutdown()
        End If
        _score = game.Serie.Count - 1
        scoreTextBlock.Text = Score
        If _score >= 5 Then
            levelText.Text = "Mad Skillz"
        ElseIf _score >= 10 Then

            levelText.Text = "MLG"
        ElseIf _score >= 15 Then

            levelText.Text = "Illuminati confirmed"
        End If
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        blueButton.IsEnabled = False
        redButton.IsEnabled = False
        greenButton.IsEnabled = False
        yellowButton.IsEnabled = False
        levelText.Text = "Scrub"
        My.Computer.Audio.Play(My.Resources.SANDSTORM_darude_, AudioPlayMode.BackgroundLoop)
    End Sub
End Class