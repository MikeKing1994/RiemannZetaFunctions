module ComplexNumbers 

type Number = 
    {
        Real: float
        Imaginary: float
    }
    static member (*) (a, b) = 
        {
            Real = a.Real*b.Real - a.Imaginary*b.Imaginary
            Imaginary = a.Imaginary*b.Real + a.Real*b.Imaginary
        }

    static member (+) (a, b) = 
        {
            Real = a.Real + b.Real
            Imaginary = a.Imaginary + b.Imaginary
        }
    static member (~-) a =
        {
            Real = -a.Real
            Imaginary = -a.Imaginary
        }
    override this.ToString() = sprintf "%g + %gi" this.Real this.Imaginary

module Math = 
    open System

    let ln x = Math.Log(x, Math.E)

    let power (x:int) (n: float) = Math.Pow(x, n)

module Number = 
    open Math 

    let real x = 
        {
            Real = x
            Imaginary = 0
        }

    /// a^(b+ic) = a^b(cos(cln(a) + isin(cln(a)))) https://www.math.toronto.edu/mathnet/questionCorner/complexexp.html
    let power (x:int) (y: Number) = 
        let coeff = power x ((float)y.Real) // a^b
        let cLnA = y.Imaginary*(ln x) // cln(a)
        {
            Real = coeff * cos(cLnA)
            Imaginary = coeff * sin(cLnA)
        }


