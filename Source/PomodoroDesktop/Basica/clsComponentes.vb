Imports System
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows

Public Class Pie
    Inherits Shape

#Region "Declarações"
    Private dblCenterX As Double
    Private dblCenterY As Double
    Private dblRadius As Double
    'Private Angle As Double
    'Private Rotation As Double
    Private blnLineStroked As Boolean = True
    Private blnArcStroked As Boolean = True
#End Region

#Region "Contrutor"
    Public Sub New()
        Call MyBase.New
        Try
            Fill = New SolidColorBrush(Colors.Yellow)
            Stroke = Brushes.Black
            StrokeThickness = 1
            blnLineStroked = True
            blnArcStroked = True
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"
    Private Sub sbDrawGeometry(p_objContext As StreamGeometryContext)

        Dim objStartPoint As Point
        Dim objArcStartPoint As Point
        Dim objArcEndPoint As Point
        Dim objArcSize As Size
        Dim blnIsLarge As Boolean

        Try

            objStartPoint = New Point(dblCenterX, dblCenterY)

            objArcStartPoint = fnComputeCartesianCoordinate(Rotation, dblRadius)
            objArcStartPoint.Offset(dblCenterX, dblCenterY)

            objArcEndPoint = fnComputeCartesianCoordinate(Rotation + Angle, dblRadius)
            objArcEndPoint.Offset(dblCenterX, dblCenterY)

            objArcSize = New Size(dblRadius, dblRadius)

            blnIsLarge = Angle > 180

            p_objContext.BeginFigure(objStartPoint, True, True)
            p_objContext.LineTo(objArcStartPoint, blnLineStroked, True)
            p_objContext.ArcTo(objArcEndPoint, objArcSize, 0, blnIsLarge, SweepDirection.Clockwise, blnArcStroked, True)
            p_objContext.LineTo(objStartPoint, blnLineStroked, True)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function fnComputeCartesianCoordinate(p_dblangle As Double, p_dblRadius As Double) As Point

        Dim dblAngleRad As Double
        Dim dblX As Double
        Dim dblY As Double

        Try

            dblAngleRad = (Math.PI / 180.0) * (p_dblangle - 90)
            dblX = p_dblRadius * Math.Cos(dblAngleRad)
            dblY = p_dblRadius * Math.Sin(dblAngleRad)

            Return New Point(dblX, dblY)

        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region

#Region "Propriedades"
    Protected Overrides ReadOnly Property DefiningGeometry As Geometry
        Get
            Dim objGeometry As StreamGeometry
            objGeometry = New StreamGeometry
            objGeometry.FillRule = FillRule.EvenOdd
            Using Context = objGeometry.Open
                Call sbDrawGeometry(Context)
            End Using
            objGeometry.Freeze()
            Return objGeometry
        End Get
    End Property
    Public Property CenterX() As Double
        Get
            Return dblCenterX
        End Get
        Set(ByVal value As Double)
            dblCenterX = value
        End Set
    End Property
    Public Property CenterY() As Double
        Get
            Return dblCenterY
        End Get
        Set(ByVal value As Double)
            dblCenterY = value
        End Set
    End Property
    Public Property Radius() As Double
        Get
            Return dblRadius
        End Get
        Set(ByVal value As Double)
            dblRadius = value
        End Set
    End Property

    Public Shared ReadOnly AngleProperty As DependencyProperty = DependencyProperty.Register("Angle", GetType(Double), GetType(Pie), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))

    Public Property Angle() As Double
        Get
            Return GetValue(AngleProperty)
        End Get
        Set(ByVal value As Double)
            SetValue(AngleProperty, value)
        End Set
    End Property

    Public Shared ReadOnly RotationProperty As DependencyProperty = DependencyProperty.Register("Rotation", GetType(Double), GetType(Pie), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Property Rotation() As Double
        Get
            Return GetValue(RotationProperty)
        End Get
        Set(ByVal value As Double)
            SetValue(RotationProperty, value)
        End Set
    End Property
    Public Property LineStroked() As Boolean
        Get
            Return blnLineStroked
        End Get
        Set(ByVal value As Boolean)
            blnLineStroked = value
        End Set
    End Property
    Public Property ArcStroked() As Boolean
        Get
            Return blnArcStroked
        End Get
        Set(ByVal value As Boolean)
            blnArcStroked = value
        End Set
    End Property
#End Region

End Class


Public Class Segment
    Inherits Shape

#Region "Declarações"
    Private dblCenterX As Double
    Private dblCenterY As Double
    Private dblInnerRadius As Double
    Private dblOuterRadius As Double
    'Private Angle As Double
    'Private Rotation As Double
    Private blnLineStroked As Boolean = True
    Private blnArcStroked As Boolean = True
#End Region

#Region "Contrutor"
    Public Sub New()
        Call MyBase.New
        Try
            Fill = New SolidColorBrush(Colors.Yellow)
            Stroke = Brushes.Black
            StrokeThickness = 1
            blnLineStroked = True
            blnArcStroked = True
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"
    Private Sub sbDrawGeometry(p_objContext As StreamGeometryContext)

        '   Dim objStartPoint As Point
        Dim objInnerArcStartPoint As Point
        Dim objInnerArcEndPoint As Point

        Dim objOuterArcStartPoint As Point
        Dim objOuterArcEndPoint As Point

        Dim objInnerArcSize As Size
        Dim objOuterArcSize As Size

        Dim blnIsLarge As Boolean

        Try

            ' objStartPoint = New Point(dblCenterX, dblCenterY) '

            objInnerArcStartPoint = fnComputeCartesianCoordinate(Rotation, dblInnerRadius)
            objInnerArcStartPoint.Offset(dblCenterX, dblCenterY)
            objInnerArcEndPoint = fnComputeCartesianCoordinate(Rotation + Angle, dblInnerRadius)
            objInnerArcEndPoint.Offset(dblCenterX, dblCenterY)
            objInnerArcSize = New Size(dblInnerRadius, dblInnerRadius)

            objOuterArcStartPoint = fnComputeCartesianCoordinate(Rotation, dblOuterRadius)
            objOuterArcStartPoint.Offset(dblCenterX, dblCenterY)
            objOuterArcEndPoint = fnComputeCartesianCoordinate(Rotation + Angle, dblOuterRadius)
            objOuterArcEndPoint.Offset(dblCenterX, dblCenterY)
            objOuterArcSize = New Size(dblOuterRadius, dblOuterRadius)

            blnIsLarge = Angle > 180

            p_objContext.BeginFigure(objInnerArcStartPoint, True, True)
            p_objContext.LineTo(objOuterArcStartPoint, blnLineStroked, True)
            p_objContext.ArcTo(objOuterArcEndPoint, objOuterArcSize, 0, blnIsLarge, SweepDirection.Clockwise, blnArcStroked, True)
            p_objContext.LineTo(objInnerArcEndPoint, blnLineStroked, True)
            p_objContext.ArcTo(objInnerArcStartPoint, objInnerArcSize, 0, blnIsLarge, SweepDirection.Counterclockwise, blnArcStroked, True)


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function fnComputeCartesianCoordinate(p_dblangle As Double, p_dblRadius As Double) As Point

        Dim dblAngleRad As Double
        Dim dblX As Double
        Dim dblY As Double

        Try

            dblAngleRad = (Math.PI / 180.0) * (p_dblangle - 90)
            dblX = p_dblRadius * Math.Cos(dblAngleRad)
            dblY = p_dblRadius * Math.Sin(dblAngleRad)

            Return New Point(dblX, dblY)

        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region

#Region "Propriedades"
    Protected Overrides ReadOnly Property DefiningGeometry As Geometry
        Get
            Dim objGeometry As StreamGeometry
            objGeometry = New StreamGeometry
            objGeometry.FillRule = FillRule.EvenOdd
            Using Context = objGeometry.Open
                Call sbDrawGeometry(Context)
            End Using
            objGeometry.Freeze()
            Return objGeometry
        End Get
    End Property
    Public Property CenterX() As Double
        Get
            Return dblCenterX
        End Get
        Set(ByVal value As Double)
            dblCenterX = value
        End Set
    End Property
    Public Property CenterY() As Double
        Get
            Return dblCenterY
        End Get
        Set(ByVal value As Double)
            dblCenterY = value
        End Set
    End Property
    Public Property InnerRadius() As Double
        Get
            Return dblInnerRadius
        End Get
        Set(ByVal value As Double)
            dblInnerRadius = value
        End Set
    End Property

    Public Property OuterRadius() As Double
        Get
            Return dblOuterRadius
        End Get
        Set(ByVal value As Double)
            dblOuterRadius = value
        End Set
    End Property

    Public Shared ReadOnly AngleProperty As DependencyProperty = DependencyProperty.Register("Angle", GetType(Double), GetType(Segment), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))

    Public Property Angle() As Double
        Get
            Return GetValue(AngleProperty)
        End Get
        Set(ByVal value As Double)
            SetValue(AngleProperty, value)
        End Set
    End Property

    Public Shared ReadOnly RotationProperty As DependencyProperty = DependencyProperty.Register("Rotation", GetType(Double), GetType(Segment), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Property Rotation() As Double
        Get
            Return GetValue(RotationProperty)
        End Get
        Set(ByVal value As Double)
            SetValue(RotationProperty, value)
        End Set
    End Property
    Public Property LineStroked() As Boolean
        Get
            Return blnLineStroked
        End Get
        Set(ByVal value As Boolean)
            blnLineStroked = value
        End Set
    End Property
    Public Property ArcStroked() As Boolean
        Get
            Return blnArcStroked
        End Get
        Set(ByVal value As Boolean)
            blnArcStroked = value
        End Set
    End Property
#End Region

End Class