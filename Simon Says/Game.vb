Public Class Game

    Private rndGen As New Random
    Private _serie As New List(Of String)
    Private _currentSeriePosition As Integer = 0 'De huidige positie in de serie
    Event PositionReset()

    Public ReadOnly Property Serie() As List(Of String) 'Een lijst die de juiste combinatie van buttons bijhoudt.
        Get
            Return New List(Of String)(_serie)
        End Get
    End Property

    Public Property CurrentSeriePosition() As Integer
        Get
            Return _currentSeriePosition
        End Get
        Set(value As Integer)
            _currentSeriePosition = value
        End Set
    End Property

    Public Sub startGame() 'Startfunctie
        addRandom()
        addRandom()
    End Sub

    Private Sub addRandom() 'Voegt een willekeurige knop toe aan de serie
        Dim random As Integer = rndGen.Next(0, 4)
        Select Case random
            Case 0 : _serie.Add("blueButton")
            Case 1 : _serie.Add("yellowButton")
            Case 2 : _serie.Add("greenButton")
            Case 3 : _serie.Add("redButton")
        End Select
    End Sub

    Public Function checkButton(buttonName As String) As Boolean 'Kijkt na of de button de juiste is
        If _currentSeriePosition >= _serie.Count Then
            _currentSeriePosition = 0
        End If

        If buttonName = _serie(_currentSeriePosition) Then
            If _currentSeriePosition >= _serie.Count - 1 Then
                addRandom()
                _currentSeriePosition = 0
                RaiseEvent PositionReset() 'Vuur event af dat aangeeft dat de _CurrentSeriePosition gereset wordt naar 0.
            Else
                _currentSeriePosition += 1
            End If
            Return True
        Else
            Return False
        End If
    End Function

End Class
