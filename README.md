# Trubus Animation

Projekt animacji tekstu "Hello TRUBUŚ" stworzony w F# z wykorzystaniem frameworka Avalonia.

## Wymagania wstępne

Przed rozpoczęciem upewnij się, że masz zainstalowane:

1. .NET 6.0 SDK lub nowszy (https://dotnet.microsoft.com/download)
2. Edytor kodu (np. Visual Studio Code, JetBrains Rider lub Visual Studio)

## Kroki instalacji

1. Utwórz nowy katalog dla projektu:

   ```
   mkdir AnimacjaTrubus
   cd AnimacjaTrubus
   ```

2. Utwórz nowy projekt F# typu console:

   ```
   dotnet new console -lang F#
   ```

3. Dodaj pakiety Avalonia do projektu:

   ```
   dotnet add package Avalonia
   dotnet add package Avalonia.Desktop
   dotnet add package Avalonia.Diagnostics
   ```

4. Otwórz plik `AnimacjaTrubus.fsproj` i upewnij się, że zawiera następujące elementy:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">
     <PropertyGroup>
       <OutputType>Exe</OutputType>
       <TargetFramework>net6.0</TargetFramework>
       <RuntimeIdentifiers>osx-arm64</RuntimeIdentifiers>
     </PropertyGroup>
     <ItemGroup>
       <Compile Include="Program.fs" />
     </ItemGroup>
     <ItemGroup>
       <PackageReference Include="Avalonia" Version="0.10.18" />
       <PackageReference Include="Avalonia.Desktop" Version="0.10.18" />
       <PackageReference Include="Avalonia.Diagnostics" Version="0.10.18" />
     </ItemGroup>
   </Project>
   ```

5. Zastąp zawartość pliku `Program.fs` kodem animacji (kod dostępny w repozytorium).

## Opis projektu

Projekt tworzy okno aplikacji z animowanym tekstem "Hello TRUBUŚ", który porusza się po ekranie i odbija od krawędzi. Wykorzystuje framework Avalonia do renderowania grafiki i obsługi okna aplikacji.

Główne komponenty kodu:

- `CustomCanvas`: Klasa dziedzicząca po `Canvas`, odpowiedzialna za renderowanie i aktualizację pozycji tekstu.
- `MainWindow`: Główne okno aplikacji, które zawiera `CustomCanvas` i konfiguruje timer do aktualizacji animacji.
- `App`: Klasa aplikacji Avalonia, która inicjalizuje główne okno.

## Rozwiązywanie problemów

Jeśli napotkasz problemy z kompilacją lub uruchomieniem projektu, upewnij się, że:

1. Masz zainstalowaną odpowiednią wersję .NET SDK.
2. Wszystkie pakiety Avalonia zostały poprawnie zainstalowane.
3. Kod w pliku `Program.fs` jest poprawnie sformatowany (wcięcia są ważne w F#).

Jeśli problemy nadal występują, sprawdź komunikaty błędów w konsoli i poszukaj rozwiązań online lub skontaktuj się z autorem projektu.

## Uruchamianie projektu

Aby skompilować i uruchomić projekt, wykonaj następujące polecenia w terminalu:

```
dotnet build
dotnet run
```
