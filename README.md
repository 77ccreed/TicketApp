# TicketApp

TicketApp on veebirakendus, mis võimaldab kasutajatel hallata kasutajatoele saadetud pöördumisi. Rakendus on loodud .NET Core ja ASP.NET Core MVC abil, kasutades C# programmeerimiskeelt.

## Ehitamine ja käivitamine

Projekti ehitamiseks ja käivitamiseks on vaja .NET Core SDK-d. Kui see on installitud, saate projekti ehitada ja käivitada järgmiste käskudega:

```sh
dotnet build
dotnet run
```

## Testimine

Projekt sisaldab ka ühikuteste, mis on loodud XUnit abil. Teste saab käivitada järgmise käsu abil kui olete projekti juurkaustas:

```sh
cd Tests
dotnet test TicketApp.Tests.csproj
```

## Struktuur

Projekt on struktureeritud järgmiselt:

- `Models/`: Sisaldab rakenduse andmemudeleid.
- `Pages/`: Sisaldab rakenduse vaateid ja nende taga olevat loogikat.
- `Properties/`: Sisaldab projekti konfiguratsioonifaile.
- `Services/`: Sisaldab rakenduse teenuseid.
- `Tests/`: Sisaldab projekti ühikuteste.
- `wwwroot/`: Sisaldab staatilisi faile, nagu CSS ja JavaScript.

## Andmebaas

Rakendus kasutab mälupõhist andmebaasi, mis on konfigureeritud failis `appsettings.json`.

## Funktsionaalsus

- Kasutaja saab sisestada pöördumise, millel peab olema kirjeldus, sisestamise aeg ja lahendamise tähtaeg.
- Kasutajale kuvatakse aktiivsed pöördumised koos kõigi väljadega nimekirjas, sorteeritult kahanevalt lahendamise tähtaja järgi.
- Pöördumised, mille lahendamise tähtajani on jäänud vähem kui 1 tund või mis on juba ületanud lahendamise tähtaja, kuvatakse nimekirjas punasena.
- Kasutaja saab nimekirjas pöördumisi lahendatuks märkida, mis kaotab pöördumise nimekirjast.
