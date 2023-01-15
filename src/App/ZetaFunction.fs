module ZetaFunction 
open ComplexNumbers

let approximateZeta s precision = 
    if s.Real <= 1 then 
        failwith "analytic continuation not defined yet"
    else 
        let mutable count = 1
        let mutable ret = Number.real 0
        while count <= precision do 
            printfn "Count is %A, next power is %A" count (Number.power count -s)
            ret <- ret + (Number.power count -s)
            count <- count + 1
        ret