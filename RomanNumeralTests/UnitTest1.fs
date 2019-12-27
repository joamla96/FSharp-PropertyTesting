module RomanNumeralTests

open NUnit.Framework
open RomanNumeralLib
open FsCheck

//[<SetUp>]
//let Setup () =
//    ()

// "Normal tests"
[<Test>]
let ``Test that 497 is CDXCVII`` () =
    let expected = "CDXCVII"
    let actual = RomanNumeralLib.arabicToRoman 497

    Assert.AreEqual(expected, actual)

module Helpers = 
    // Set up a filter for FsCheck to ensure we're within the libarys bounds.
    let testWithRange f num =
        let romanIsInRange i = (i >= 1) && (i <= 4000)

        romanIsInRange num ==> lazy (f num)


// Verifyable property
[<Test>]
let ``Test that roman numerals nave no more than one V`` () =
    let prop num = 
        RomanNumeralLib.arabicToRoman num
        |> RomanProperties.``has max rep of one V``

    Check.Quick (Helpers.testWithRange prop)

// Test for expected failiures
// Falsifiable property
// Idea of these: If the test fails, write "normal (oracle)" tests to try narrow down.
[<Test>]
let ``Test that roman numerals have no more than two Xs`` () =
    let hasMaxRepetitionOfTwoXs roman =
        RomanProperties.maxRepetitionProperty "X" 2 roman

    let prop num =
        RomanNumeralLib.arabicToRoman num
        |> hasMaxRepetitionOfTwoXs

    Check.QuickThrowOnFailure (Helpers.testWithRange prop )