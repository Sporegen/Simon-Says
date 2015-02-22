Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Partial Public Class HexButton

    Private _hexColor As Brush
    Public Property HexagonColor() As Brush
        Get
            Return _hexColor
        End Get
        Set(ByVal value As Brush)
            _hexColor = value

            MainHexagon.Fill = _hexColor
        End Set
    End Property

    Private Sub blinkUp() Handles MainHexagon.MouseEnter
        MainHexagon.Fill = Brushes.WhiteSmoke
    End Sub

    Private Sub blinkDown() Handles MainHexagon.MouseLeave
        MainHexagon.Fill = _hexColor
    End Sub

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
    End Sub
End Class
