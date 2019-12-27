module RomanProperties
    
    // Helper function. Determines that instances of ch appear a max amount of count times.
    let maxRepetitionProperty ch count (input:string) = 
        let find = String.replicate (count+1) ch
        input.Contains find |> not

    let ``has max rep of one V`` roman = 
        maxRepetitionProperty "V" 1 roman

    let ``has max rep of three Xs`` roman =
        maxRepetitionProperty "X" 3 roman