// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Media
open Avalonia.Threading
open System

type CustomCanvas() =
    inherit Canvas()

    let mutable position = Point(0.0, 0.0)
    let mutable velocity = Vector(3.0, 2.0)
    let textSize = Size(200.0, 50.0)

    member this.UpdatePosition() =
        let newX = position.X + velocity.X
        let newY = position.Y + velocity.Y

        if newX <= 0.0 || newX + textSize.Width >= this.Bounds.Width then
            velocity <- Vector(-velocity.X, velocity.Y)
        if newY <= 0.0 || newY + textSize.Height >= this.Bounds.Height then
            velocity <- Vector(velocity.X, -velocity.Y)

        let clampX x = 
            if x <= 0.0 then 0.0
            elif x + textSize.Width >= this.Bounds.Width then this.Bounds.Width - textSize.Width
            else x

        let clampY y =
            if y <= 0.0 then 0.0
            elif y + textSize.Height >= this.Bounds.Height then this.Bounds.Height - textSize.Height
            else y

        position <- Point(clampX newX, clampY newY)
        this.InvalidateVisual()

    override this.Render(context: DrawingContext) =
        base.Render(context)
        let text = "Hello TRUBUŚ"
        let formattedText = new FormattedText(
            text,
            Typeface.Default,
            36.0,
            TextAlignment.Center,
            TextWrapping.NoWrap,
            textSize)
        
        context.DrawText(Brushes.White, position, formattedText)

type MainWindow() as this =
    inherit Window()

    let canvas = new CustomCanvas()
    let timer = new DispatcherTimer()

    do
        this.Title <- "Animacja Hello TRUBUŚ"
        this.Width <- 800.0
        this.Height <- 600.0
        this.Background <- Brushes.Black
        this.Content <- canvas

        timer.Interval <- TimeSpan.FromMilliseconds(16.0) // około 60 FPS
        timer.Tick.Add(fun _ -> canvas.UpdatePosition())
        timer.Start()

    override this.OnClosed(e) =
        timer.Stop()
        base.OnClosed(e)

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.Add (Avalonia.Themes.Default.DefaultTheme())

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow()
        | _ -> ()

module Program =
    [<EntryPoint>]
    let main argv =
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .StartWithClassicDesktopLifetime(argv)
