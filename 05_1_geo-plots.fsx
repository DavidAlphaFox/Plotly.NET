(**
// can't yet format YamlFrontmatter (["title: Scatter and line plots on Geo maps"; "category: Geo map charts"; "categoryindex: 6"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Scatter and line plots on Geo maps

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=05_1_geo-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/05_1_geo-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/05_1_geo-plots.ipynb)

*Summary:* This example shows how to create Point and Line charts on geo maps in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 

let cityNames = [
    "Montreal"; "Toronto"; "Vancouver"; "Calgary"; "Edmonton";
    "Ottawa"; "Halifax"; "Victoria"; "Winnepeg"; "Regina"
]

let lon = [
    -73.57; -79.24; -123.06; -114.1; -113.28;
    -75.43; -63.57; -123.21; -97.13; -104.6
]
let lat = [
    45.5; 43.4; 49.13; 51.1; 53.34; 45.24;
    44.64; 48.25; 49.89; 50.45
]
(**
The simplest type of geo plot is plotting the (lon,lat) pairs of a location via `Chart.PointGeo`. 
Here is an example using the location of Canadian cities:

*)
open Plotly.NET.LayoutObjects

let pointGeo =
    Chart.PointGeo(
        lon,
        lat,
        Labels=cityNames,
        TextPosition=StyleParam.TextPosition.TopCenter
    )
    |> Chart.withGeoStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        CountryColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="bfdb668d-93d6-4cc9-8ea8-2c7b5f9000e1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_bfdb668d93d64cc98ea82c7b5f9000e1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers+text","lon":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],"lat":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],"marker":{},"text":["Montreal","Toronto","Vancouver","Calgary","Edmonton","Ottawa","Halifax","Victoria","Winnepeg","Regina"],"textposition":"top center"}];
            var layout = {"geo":{"scope":"north america","projection":{"type":"azimuthal equal area"},"countrycolor":"lightgrey"},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {};
            Plotly.newPlot('bfdb668d-93d6-4cc9-8ea8-2c7b5f9000e1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_bfdb668d93d64cc98ea82c7b5f9000e1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_bfdb668d93d64cc98ea82c7b5f9000e1();
            }
</script>
*)
(**
To connect the given (lon,lat) pairs via straight lines, use `Chart.LineGeo`. 
Below is an example that pulls external data as a Deedle data 
frame containing the source and target locations of American Airlines flights from Feb. 2011:

*)
#r "nuget: Deedle"
#r "nuget: FSharp.Data"
open Deedle
open FSharp.Data
open System.IO
open System.Text

let data = 
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/c34aaa0b1b3cddad335173cb7bc0181897201ee6/2011_february_aa_flight_paths.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
let coords = Series.zipInner startCoords endCoords |> Series.values

let flights = 
    coords 
    |> Seq.mapi (fun i (startCoords,endCoords) ->
        Chart.LineGeo(
            [startCoords; endCoords],
            Opacity = opacityVals.[i],
            Color = Color.fromString "red"
        )
    )
    |> Chart.combine
    |> Chart.withLegend(false)
    |> Chart.withGeoStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        ShowLand=true,
        LandColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize(0,0,50,0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"(* output: 
<div id="c0068a0c-8fb2-4641-8451-6281331e702b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c0068a0c8fb2464184516281331e702b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"lines","lon":[-97.0372,-106.6091944],"lat":[32.89595056,35.04022222],"opacity":0.48577680525164113,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-97.66987194],"lat":[41.979595,30.19453278],"opacity":0.18161925601750548,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-72.68322833],"lat":[32.89595056,41.93887417],"opacity":0.1772428884026258,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-72.68322833],"lat":[18.43941667,41.93887417],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-86.75354972],"lat":[32.89595056,33.56294306],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-86.67818222],"lat":[25.79325,36.12447667],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-71.00517917],"lat":[32.89595056,42.3643475],"opacity":0.4617067833698031,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-71.00517917],"lat":[25.79325,42.3643475],"opacity":0.4288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-71.00517917],"lat":[41.979595,42.3643475],"opacity":0.47045951859956237,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-71.00517917],"lat":[18.43941667,42.3643475],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-64.97336111,-71.00517917],"lat":[18.33730556,42.3643475],"opacity":0.04814004376367615,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-76.66819833],"lat":[25.79325,39.17540167],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-76.66819833],"lat":[18.43941667,39.17540167],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-80.94312583],"lat":[32.89595056,35.21401111],"opacity":0.3938730853391685,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-104.70025],"lat":[32.89595056,38.80580556],"opacity":0.3041575492341357,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-84.219375],"lat":[32.89595056,39.90237583],"opacity":0.1137855579868709,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-77.03772222],"lat":[32.89595056,38.85208333],"opacity":0.6433260393873085,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-104.6670019],"lat":[25.79325,39.85840806],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-104.6670019],"lat":[41.979595,39.85840806],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-84.42694444,-97.0372],"lat":[33.64044444,32.89595056],"opacity":0.6345733041575492,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.66987194,-97.0372],"lat":[30.19453278,32.89595056],"opacity":0.8971553610503282,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-86.67818222,-97.0372],"lat":[36.12447667,32.89595056],"opacity":0.47702407002188185,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.3584969,-97.0372],"lat":[34.20061917,32.89595056],"opacity":0.2275711159737418,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-76.66819833,-97.0372],"lat":[39.17540167,32.89595056],"opacity":0.35667396061269147,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-82.89188278,-97.0372],"lat":[39.99798528,32.89595056],"opacity":0.1137855579868709,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-104.6670019,-97.0372],"lat":[39.85840806,32.89595056],"opacity":0.6105032822757112,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-83.34883583,-97.0372],"lat":[42.21205889,32.89595056],"opacity":0.2844638949671772,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-106.9176953,-97.0372],"lat":[39.64256778,32.89595056],"opacity":0.1487964989059081,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-74.16866056,-97.0372],"lat":[40.69249722,32.89595056],"opacity":0.33916849015317285,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-119.7181389,-97.0372],"lat":[36.77619444,32.89595056],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.15275,-97.0372],"lat":[26.07258333,32.89595056],"opacity":0.3676148796498906,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-86.77310944,-97.0372],"lat":[34.6404475,32.89595056],"opacity":0.17286652078774617,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-95.33972222,-97.0372],"lat":[29.98047222,32.89595056],"opacity":0.3544857768052516,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-97.0372],"lat":[33.94253611,32.89595056],"opacity":1.0,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-94.71390556,-97.0372],"lat":[39.29760528,32.89595056],"opacity":0.47702407002188185,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-81.31602778,-97.0372],"lat":[28.42888889,32.89595056],"opacity":0.5470459518599562,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-89.97666667,-97.0372],"lat":[35.04241667,32.89595056],"opacity":0.23413566739606126,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-98.23861111,-97.0372],"lat":[26.17583333,32.89595056],"opacity":0.23413566739606126,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-97.0372],"lat":[25.79325,32.89595056],"opacity":0.612691466083151,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-93.2169225,-97.0372],"lat":[44.88054694,32.89595056],"opacity":0.35667396061269147,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-107.8938333,-97.0372],"lat":[38.50886722,32.89595056],"opacity":0.0175054704595186,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-156.4304578,-97.0372],"lat":[20.89864972,32.89595056],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.60073389,-97.0372],"lat":[35.39308833,32.89595056],"opacity":0.42669584245076586,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-95.89417306,-97.0372],"lat":[41.30251861,32.89595056],"opacity":0.2975929978118162,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-97.0372],"lat":[41.979595,32.89595056],"opacity":0.9026258205689278,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-75.24114083,-97.0372],"lat":[39.87195278,32.89595056],"opacity":0.3522975929978118,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-112.0080556,-97.0372],"lat":[33.43416667,32.89595056],"opacity":0.6017505470459519,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-77.31966667,-97.0372],"lat":[37.50516667,32.89595056],"opacity":0.18161925601750548,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-119.7680647,-97.0372],"lat":[39.49857611,32.89595056],"opacity":0.16411378555798686,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-117.1896567,-97.0372],"lat":[32.73355611,32.89595056],"opacity":0.5470459518599562,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-98.46977778,-97.0372],"lat":[29.53369444,32.89595056],"opacity":0.9037199124726477,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-85.736,-97.0372],"lat":[38.17438889,32.89595056],"opacity":0.17943107221006566,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-122.3748433,-97.0372],"lat":[37.61900194,32.89595056],"opacity":0.5754923413566739,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-121.9290089,-97.0372],"lat":[37.36186194,32.89595056],"opacity":0.3479212253829322,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-111.9777731,-97.0372],"lat":[40.78838778,32.89595056],"opacity":0.3063457330415755,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-90.35998972,-97.0372],"lat":[38.74768694,32.89595056],"opacity":0.5317286652078774,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-94.30681111,-97.0372],"lat":[36.28186944,32.89595056],"opacity":0.05470459518599562,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-83.34883583],"lat":[25.79325,42.21205889],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.87260917,-106.9176953],"lat":[40.77724306,39.64256778],"opacity":0.0087527352297593,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-106.9176953],"lat":[41.979595,39.64256778],"opacity":0.0700218818380744,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-106.3778056],"lat":[32.89595056,31.80666667],"opacity":0.474835886214442,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-74.16866056],"lat":[33.94253611,40.69249722],"opacity":0.05908096280087528,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-74.16866056],"lat":[25.79325,40.69249722],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-80.15275],"lat":[40.63975111,26.07258333],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-107.2176597],"lat":[32.89595056,40.48118028],"opacity":0.0700218818380744,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-157.9224072],"lat":[32.89595056,21.31869111],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-157.9224072],"lat":[33.94253611,21.31869111],"opacity":0.2363238512035011,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-77.45580972],"lat":[32.89595056,38.94453194],"opacity":0.33698030634573306,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-77.45580972],"lat":[33.94253611,38.94453194],"opacity":0.18161925601750548,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-77.45580972],"lat":[25.79325,38.94453194],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-95.33972222],"lat":[25.79325,29.98047222],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-97.43304583],"lat":[32.89595056,37.64995889],"opacity":0.23413566739606126,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-86.29438417],"lat":[32.89595056,39.71732917],"opacity":0.3041575492341357,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-110.7377389],"lat":[32.89595056,43.60732417],"opacity":0.0262582056892779,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-81.68786111],"lat":[32.89595056,30.49405556],"opacity":0.2363238512035011,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.66987194,-73.77892556],"lat":[30.19453278,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-73.77892556],"lat":[32.89595056,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-106.9176953,-73.77892556],"lat":[39.64256778,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-81.31602778,-73.77892556],"lat":[28.42888889,40.63975111],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-73.77892556],"lat":[25.79325,40.63975111],"opacity":0.4288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-122.3093131,-73.77892556],"lat":[47.44898194,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-122.3748433,-73.77892556],"lat":[37.61900194,40.63975111],"opacity":0.3041575492341357,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-64.97336111,-73.77892556],"lat":[18.33730556,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-82.53325,-73.77892556],"lat":[27.97547222,40.63975111],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-115.1523333],"lat":[32.89595056,36.08036111],"opacity":0.6225382932166302,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-115.1523333],"lat":[40.63975111,36.08036111],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-115.1523333],"lat":[33.94253611,36.08036111],"opacity":0.24288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-115.1523333],"lat":[41.979595,36.08036111],"opacity":0.3063457330415755,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.66987194,-118.4080744],"lat":[30.19453278,33.94253611],"opacity":0.1772428884026258,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-86.67818222,-118.4080744],"lat":[36.12447667,33.94253611],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-71.00517917,-118.4080744],"lat":[42.3643475,33.94253611],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-106.9176953,-118.4080744],"lat":[39.64256778,33.94253611],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-118.4080744],"lat":[40.63975111,33.94253611],"opacity":0.5995623632385121,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-156.0456314,-118.4080744],"lat":[19.73876583,33.94253611],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-156.4304578,-118.4080744],"lat":[20.89864972,33.94253611],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-118.4080744],"lat":[41.979595,33.94253611],"opacity":0.5426695842450766,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-90.35998972,-118.4080744],"lat":[38.74768694,33.94253611],"opacity":0.18161925601750548,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-86.67818222,-73.87260917],"lat":[36.12447667,40.77724306],"opacity":0.11159737417943107,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-73.87260917],"lat":[32.89595056,40.77724306],"opacity":0.849015317286652,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-90.35998972,-73.87260917],"lat":[38.74768694,40.77724306],"opacity":0.22538293216630198,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-159.3389581],"lat":[33.94253611,21.97598306],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-81.31602778],"lat":[33.94253611,28.42888889],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-81.31602778],"lat":[25.79325,28.42888889],"opacity":0.49015317286652077,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-84.42694444,-80.29055556],"lat":[33.64044444,25.79325],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-72.68322833,-80.29055556],"lat":[41.93887417,25.79325],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-77.03772222,-80.29055556],"lat":[38.85208333,25.79325],"opacity":0.5514223194748359,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-106.9176953,-80.29055556],"lat":[39.64256778,25.79325],"opacity":0.0525164113785558,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-115.1523333,-80.29055556],"lat":[36.08036111,25.79325],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-80.29055556],"lat":[33.94253611,25.79325],"opacity":0.4288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.87260917,-80.29055556],"lat":[40.77724306,25.79325],"opacity":0.6728665207877462,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-93.2169225,-80.29055556],"lat":[44.88054694,25.79325],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-80.29055556],"lat":[41.979595,25.79325],"opacity":0.5525164113785558,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-75.24114083,-80.29055556],"lat":[39.87195278,25.79325],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-112.0080556,-80.29055556],"lat":[33.43416667,25.79325],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-122.3748433,-80.29055556],"lat":[37.61900194,25.79325],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-80.29055556],"lat":[18.43941667,25.79325],"opacity":0.49015317286652077,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-95.88824167,-80.29055556],"lat":[36.19837222,25.79325],"opacity":0.00437636761487965,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-93.2169225],"lat":[41.979595,44.88054694],"opacity":0.175054704595186,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-90.25802778],"lat":[32.89595056,29.99338889],"opacity":0.3676148796498906,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-90.25802778],"lat":[25.79325,29.99338889],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-90.25802778],"lat":[41.979595,29.99338889],"opacity":0.16301969365426697,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-117.6011944],"lat":[32.89595056,34.056],"opacity":0.24288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-77.03772222,-87.90446417],"lat":[38.85208333,41.979595],"opacity":0.3544857768052516,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-74.16866056,-87.90446417],"lat":[40.69249722,41.979595],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.15275,-87.90446417],"lat":[26.07258333,41.979595],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-107.2176597,-87.90446417],"lat":[40.48118028,41.979595],"opacity":0.0525164113785558,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-157.9224072,-87.90446417],"lat":[21.31869111,41.979595],"opacity":0.05032822757111598,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-110.7377389,-87.90446417],"lat":[43.60732417,41.979595],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-87.90446417],"lat":[40.63975111,41.979595],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.87260917,-87.90446417],"lat":[40.77724306,41.979595],"opacity":0.9409190371991247,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-94.71390556,-87.90446417],"lat":[39.29760528,41.979595],"opacity":0.23413566739606126,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-81.31602778,-87.90446417],"lat":[28.42888889,41.979595],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-78.78747222,-87.90446417],"lat":[35.87763889,41.979595],"opacity":0.17067833698030635,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-119.7680647,-87.90446417],"lat":[39.49857611,41.979595],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-117.1896567,-87.90446417],"lat":[32.73355611,41.979595],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-98.46977778,-87.90446417],"lat":[29.53369444,41.979595],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-121.9290089,-87.90446417],"lat":[37.36186194,41.979595],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-87.90446417],"lat":[18.43941667,41.979595],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-90.35998972,-87.90446417],"lat":[38.74768694,41.979595],"opacity":0.5284463894967177,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-95.88824167,-87.90446417],"lat":[36.19837222,41.979595],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-110.9410278,-87.90446417],"lat":[32.11608333,41.979595],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-76.20122222],"lat":[32.89595056,36.89461111],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-80.09559417],"lat":[32.89595056,26.68316194],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-80.09559417],"lat":[41.979595,26.68316194],"opacity":0.16411378555798686,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-122.5975],"lat":[32.89595056,45.58872222],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-75.24114083],"lat":[41.979595,39.87195278],"opacity":0.12035010940919037,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-75.24114083],"lat":[18.43941667,39.87195278],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-112.0080556],"lat":[41.979595,33.43416667],"opacity":0.3063457330415755,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-80.23287083],"lat":[32.89595056,40.49146583],"opacity":0.18599562363238512,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-116.5062531],"lat":[32.89595056,33.82921556],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-116.5062531],"lat":[41.979595,33.82921556],"opacity":0.0700218818380744,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-78.78747222],"lat":[32.89595056,35.87763889],"opacity":0.3041575492341357,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-78.78747222],"lat":[25.79325,35.87763889],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-81.75516667],"lat":[32.89595056,26.53616667],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-81.75516667],"lat":[41.979595,26.53616667],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-117.1896567],"lat":[40.63975111,32.73355611],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-122.3093131],"lat":[32.89595056,47.44898194],"opacity":0.4288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-122.3093131],"lat":[41.979595,47.44898194],"opacity":0.23413566739606126,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-157.9224072,-122.3748433],"lat":[21.31869111,37.61900194],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-122.3748433],"lat":[33.94253611,37.61900194],"opacity":0.3676148796498906,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-122.3748433],"lat":[41.979595,37.61900194],"opacity":0.35667396061269147,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-66.00183333],"lat":[32.89595056,18.43941667],"opacity":0.13129102844638948,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-77.45580972,-66.00183333],"lat":[38.94453194,18.43941667],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-73.77892556,-66.00183333],"lat":[40.63975111,18.43941667],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-118.4080744,-66.00183333],"lat":[33.94253611,18.43941667],"opacity":0.0175054704595186,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-121.5907669],"lat":[32.89595056,38.69542167],"opacity":0.24507658643326038,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-117.8682225],"lat":[32.89595056,33.67565861],"opacity":0.6323851203501094,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-117.8682225],"lat":[41.979595,33.67565861],"opacity":0.16630196936542668,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-77.03772222,-90.35998972],"lat":[38.85208333,38.74768694],"opacity":0.2188183807439825,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-90.35998972],"lat":[25.79325,38.74768694],"opacity":0.1838074398249453,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-64.97336111],"lat":[25.79325,18.33730556],"opacity":0.12253829321663019,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-64.79855556],"lat":[25.79325,17.70188889],"opacity":0.06783369803063458,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-82.53325],"lat":[32.89595056,27.97547222],"opacity":0.4288840262582057,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-80.29055556,-82.53325],"lat":[25.79325,27.97547222],"opacity":0.32603938730853393,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-87.90446417,-82.53325],"lat":[41.979595,27.97547222],"opacity":0.16411378555798686,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-66.00183333,-82.53325],"lat":[18.43941667,27.97547222],"opacity":0.061269146608315096,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-95.88824167],"lat":[32.89595056,36.19837222],"opacity":0.42669584245076586,"marker":{"color":"red"}},{"type":"scattergeo","mode":"lines","lon":[-97.0372,-110.9410278],"lat":[32.89595056,32.11608333],"opacity":0.45842450765864334,"marker":{"color":"red"}}];
            var layout = {"showlegend":false,"geo":{"scope":"north america","projection":{"type":"azimuthal equal area"},"showland":true,"landcolor":"lightgrey"},"margin":{"l":0,"r":0,"t":50,"b":0},"title":{"text":"Feb. 2011 American Airline flights"}};
            var config = {};
            Plotly.newPlot('c0068a0c-8fb2-4641-8451-6281331e702b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c0068a0c8fb2464184516281331e702b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c0068a0c8fb2464184516281331e702b();
            }
</script>
*)

