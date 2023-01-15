open ComplexNumbers
open ZetaFunction
open FSharp.Charting

let s = 
    {
        Real = 3
        Imaginary = 5
    }

let data = [ for x in 1.0 .. 10.0 -> x, (ZetaFunction.approximateZeta (Number.real x) 3)]

Chart.Line data