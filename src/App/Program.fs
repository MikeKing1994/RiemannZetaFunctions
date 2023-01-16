open ComplexNumbers
open ZetaFunction
open Plotly.NET
open System

let s = 
    {
        Real = 3
        Imaginary = 5
    }

//let data = [ for x in 1.0 .. 10.0 -> x, (ZetaFunction.approximateZeta (Number.real x) 3)]
//
//Chart.Line data

let two = (ZetaFunction.approximateZeta (Number.real 2) 100)
let three = (ZetaFunction.approximateZeta (Number.real 3) 100)
let four = (ZetaFunction.approximateZeta (Number.real 4) 100)

let point3d = 
    Chart.Point3D(
        [
            2, two.Real, two.Imaginary
            3, three.Real, three.Imaginary
            4, four.Real, four.Imaginary
        ],
        MultiText = ["A"; "B"; "C"],
        TextPosition = StyleParam.TextPosition.BottomCenter
    )
    |> Chart.withXAxisStyle("S as non-complex", Id=StyleParam.SubPlotId.Scene 1) // in contrast to 2D plots, x and y axes of 3D charts have to be set via the scene object
    |> Chart.withYAxisStyle("Re(z(s))", Id=StyleParam.SubPlotId.Scene 1) // in contrast to 2D plots, x and y axes of 3D charts have to be set via the scene object
    |> Chart.withZAxisStyle("Im(z(s))")
    |> Chart.withSize(800.,800.)

point3d |> Chart.show