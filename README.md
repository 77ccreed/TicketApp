# TicketApp

TicketApp on veebirakendus, mis võimaldab kasutajatel luua ja hallata pileteid. Rakendus on loodud .NET Core ja ASP.NET Core MVC abil, kasutades C# programmeerimiskeelt.

## Ehitamine ja käivitamine

Projekti ehitamiseks ja käivitamiseks on vaja .NET Core SDK-d. Kui see on installitud, saate projekti ehitada ja käivitada järgmiste käskudega:

```sh
dotnet build
dotnet run
```

## Testimine

Projekt sisaldab ka ühikuteste, mis on loodud XUnit abil. Teste saab käivitada järgmise käsu abil:

```sh
dotnet test
```

## Struktuur

Projekt on struktureeritud järgmiselt:

- [``Models/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2FModels%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\Models\"): Sisaldab rakenduse andmemudeleid.
- [``Pages/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2FPages%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\Pages\"): Sisaldab rakenduse vaateid ja nende taga olevat loogikat.
- [``Properties/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2FProperties%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\Properties\"): Sisaldab projekti konfiguratsioonifaile.
- [``Tests/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2FTests%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\Tests\"): Sisaldab projekti ühikuteste.
- [``wwwroot/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2Fwwwroot%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\wwwroot\"): Sisaldab staatilisi faile, nagu CSS ja JavaScript.

## Andmebaas

Rakendus kasutab SQLite andmebaasi, mis on konfigureeritud failis [``appsettings.json``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2Fappsettings.json%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\appsettings.json").

## .gitignore

Projekt sisaldab .gitignore faili, mis ignoreerib teatud tüüpi faile ja kaustu, mida tavaliselt ei soovita versioonikontrolli alla panna. See hõlmab näiteks .NET ehitusväljundi kaustu ([``bin/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2Fbin%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\bin\") ja [``obj/``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fkiur%2FDocuments%2FGitHub%2FTicketApp%2Fobj%2F%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "c:\Users\kiur\Documents\GitHub\TicketApp\obj\")), Visual Studio ajutisi faile ja palju muud.
