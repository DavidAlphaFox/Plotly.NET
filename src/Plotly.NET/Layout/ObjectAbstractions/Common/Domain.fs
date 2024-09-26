namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Domain() =
    inherit DynamicObj()

    /// Initialized Dimensions object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Y: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Row: int,
            [<Optional; DefaultParameterValue(null)>] ?Column: int
        ) =
        Domain() |> Domain.style (?X = X, ?Y = Y, ?Row = Row, ?Column = Column)


    // Applies the styles to Dimensions()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Y: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Row: int,
            [<Optional; DefaultParameterValue(null)>] ?Column: int
        ) =
        (fun (dom: Domain) ->
            X |> DynObj.setOptionalPropertyBy dom "x" StyleParam.Range.convert
            Y |> DynObj.setOptionalPropertyBy dom "y" StyleParam.Range.convert
            Row |> DynObj.setOptionalProperty dom "row"
            Column |> DynObj.setOptionalProperty dom "column"

            // out ->
            dom)
