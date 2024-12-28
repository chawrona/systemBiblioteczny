
# System Biblioteczny
**Dawid Chawrona**\
Student III roku kierunku Informatyka\
I stopień, studia stacjonarne\
Nr albumu: 160924\
Grupa L6


## Opis działania aplikacji
Istnieje możliwość rejestracji i zalogowania.

Wszyscy użytkownicy mogą przeglądać zapisane w aplikacji książki.  Po wejściu w konkretną książkę mogą zobaczyć jej dokładniejszy opis, bądź też po zalogowaniu ją zarezerwować.

Administrator może tworzyć książki, edytować je oraz usuwać. Posiada podgląd obecnych rezerwacji, których może zmienić status na wypożyczone. Wypożyczone książki może zmienić na oddane. \
Widzi również w archiwum wszystkie wypożyczenia jakie tylko się odbyły (ktoś rzeczywiście odebrał książkę). 

Rezerwacje nieodebrane w odpowiednim czasie są usuwane.

## Testowi użytkownicy
- Zwykły użytkownik - user@user.user User123!
- Administrator - admin@admin.admin Admin123!

## Wymagania
System operacyjny:
Windows 10/11 z obsługą .NET 8.0.
### Oprogramowanie:
- .NET SDK 8.0 (https://dotnet.microsoft.com/download/dotnet/8.0) 
- SQL Server (lub LocalDB).
### Pakiety NuGet (zainstalowane w projekcie)
 - Microsoft.AspNetCore.Identity.EntityFrameworkCore  
- Microsoft.AspNetCore.Identity.UI  
- Microsoft.EntityFrameworkCore  
- Microsoft.EntityFrameworkCore.Design  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.VisualStudio.Web.CodeGeneration.Design  

## Instalacja
Sklonuj repozytorium projektu:  
   ```bash
   git clone https://github.com/chawrona/systemBiblioteczny.git
   ```
 Przejdź do folderu projektu:

```bash
cd <nazwa_folderu_projektu>
```

Przywróć zależności NuGet:
```bash
dotnet restore
```
### Przygotowanie bazy danych
Utwórz lokalną bazę danych w wierzu poleceń
```bash
sqllocaldb create "chawrona"
```
Następnie, połącz się z serwerem poprzez  SQL Server Management Studio
```bash
(localdb)\chawrona
```
I utwórz bazę danych o nazwie "chawrona"
```bash
CREATE DATABASE chawrona;
```
#### Connection String zawarty w aplikacji:

```json
"ConnectionStrings": {
  "DevConnection": "Server=(localdb)\\chawrona;Database=chawrona;Trusted_Connection=TrueTrustServerCertificate=True;",
}
```
### Utwórz migrację i zaaktualizuj baze danych
```bash
add-migration <nazwa>
```
```bash
update-database
```