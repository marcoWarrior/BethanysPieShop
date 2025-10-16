# Guida Introduttiva - Bethany's Pie Shop

Questa guida ti aiuterà a clonare, configurare ed eseguire l'applicazione web Bethany's Pie Shop sulla tua macchina locale.

## Indice
- [Prerequisiti](#prerequisiti)
- [Clonare il Repository](#clonare-il-repository)
- [Configurazione del Database](#configurazione-del-database)
- [Compilare ed Eseguire l'Applicazione](#compilare-ed-eseguire-lapplicazione)
- [Accedere all'Applicazione](#accedere-allapplicazione)
- [Funzionalità dell'Applicazione](#funzionalità-dellapplicazione)
- [Risoluzione dei Problemi](#risoluzione-dei-problemi)

## Prerequisiti

Prima di iniziare, assicurati di avere installato quanto segue:

### Software Richiesto
1. **.NET 8.0 SDK** o superiore
   - Scarica da: https://dotnet.microsoft.com/download
   - Verifica l'installazione: `dotnet --version`

2. **Git**
   - Scarica da: https://git-scm.com/downloads
   - Verifica l'installazione: `git --version`

3. **Database** (scegli una delle seguenti opzioni):
   
   **Opzione A: SQL Server LocalDB (Consigliato per Windows)**
   - Incluso con Visual Studio 2019/2022
   - Oppure scarica SQL Server Express: https://www.microsoft.com/sql-server/sql-server-downloads
   
   **Opzione B: SQLite (Alternativa multipiattaforma)**
   - Non richiede installazione, verrà gestito automaticamente da .NET

### Editor/IDE Consigliati
- **Visual Studio 2022** (Windows/Mac) - Include tutto
- **Visual Studio Code** con estensione C# - Leggero e multipiattaforma
- **JetBrains Rider** - IDE completo multipiattaforma

## Clonare il Repository

1. Apri il terminale (o Command Prompt/PowerShell su Windows)

2. Naviga nella cartella dove vuoi salvare il progetto:
   ```bash
   cd C:\Projects  # Windows
   # oppure
   cd ~/Projects   # macOS/Linux
   ```

3. Clona il repository:
   ```bash
   git clone https://github.com/marcoWarrior/BethanysPieShop.git
   ```

4. Entra nella cartella del progetto:
   ```bash
   cd BethanysPieShop
   ```

## Configurazione del Database

Il progetto è configurato per usare SQL Server LocalDB di default. Se preferisci usare SQLite, segui questi passaggi:

### Opzione 1: Usare SQL Server LocalDB (Default)

Se usi Windows con SQL Server LocalDB installato, non serve alcuna configurazione. Il database verrà creato automaticamente al primo avvio.

### Opzione 2: Passare a SQLite

Per usare SQLite (consigliato per macOS/Linux o per facilità d'uso):

1. Apri il file `BethanysPieShop/appsettings.json`

2. Modifica la stringa di connessione:
   ```json
   {
     "ConnectionStrings": {
       "BethanysPieShopDbContextConnection": "Data Source=BethanysPieShop.db"
     }
   }
   ```

3. Apri il file `BethanysPieShop/Program.cs`

4. Trova questa riga (circa alla riga 14):
   ```csharp
   options.UseSqlServer(connectionString);
   ```

5. Sostituiscila con:
   ```csharp
   options.UseSqlite(connectionString);
   ```

6. Trova anche la seconda occorrenza (circa alla riga 50) e fai lo stesso cambiamento.

## Compilare ed Eseguire l'Applicazione

### Passo 1: Ripristinare i Pacchetti NuGet

```bash
dotnet restore
```

### Passo 2: Applicare le Migrazioni del Database

```bash
dotnet ef database update --project BethanysPieShop
```

Se il comando `dotnet ef` non è installato, esegui prima:
```bash
dotnet tool install --global dotnet-ef
```

### Passo 3: Compilare l'Applicazione

```bash
dotnet build
```

### Passo 4: Eseguire i Test (Opzionale)

```bash
dotnet test
```

### Passo 5: Avviare l'Applicazione

```bash
cd BethanysPieShop
dotnet run
```

Dovresti vedere un output simile a:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

## Accedere all'Applicazione

1. Apri il tuo browser web preferito

2. Naviga all'indirizzo:
   - **HTTP:** http://localhost:5000
   - **HTTPS:** https://localhost:5001 (raccomandato)

3. Vedrai la homepage di Bethany's Pie Shop con le torte disponibili!

## Funzionalità dell'Applicazione

### Cosa Puoi Fare

1. **Sfogliare le Torte**
   - Visualizza tutte le torte disponibili nella homepage
   - Vedi le torte della settimana
   - Esplora diverse categorie (Fruit Pies, Cheese Cakes, Seasonal Pies)

2. **Visualizzare i Dettagli**
   - Clicca su una torta per vedere i dettagli completi
   - Controlla prezzo, descrizione e disponibilità

3. **Gestire il Carrello**
   - Aggiungi torte al carrello
   - Visualizza il contenuto del carrello
   - Modifica le quantità

4. **Effettuare Ordini**
   - Completa il checkout con i tuoi dati
   - Invia l'ordine

5. **Autenticazione (Opzionale)**
   - Registra un nuovo account
   - Effettua il login
   - Gestisci il tuo profilo

### Tecnologie Utilizzate

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core** - ORM per database
- **ASP.NET Core Identity** - Autenticazione e autorizzazione
- **Razor Pages** - Alcune pagine dell'interfaccia
- **MVC** - Pattern architetturale
- **Blazor** - Componenti interattivi
- **Bootstrap** - Framework CSS per lo stile

## Risoluzione dei Problemi

### Problema: "Connection string not found"

**Soluzione:** Assicurati che il file `appsettings.json` contenga la stringa di connessione corretta.

### Problema: "Unable to connect to SQL Server"

**Soluzione:** 
- Verifica che SQL Server LocalDB sia installato e in esecuzione
- Oppure passa a SQLite seguendo le istruzioni sopra

### Problema: "dotnet ef command not found"

**Soluzione:** Installa Entity Framework Core Tools:
```bash
dotnet tool install --global dotnet-ef
```

### Problema: Porta già in uso

**Soluzione:** 
- Chiudi altre applicazioni che usano le porte 5000/5001
- Oppure modifica le porte in `BethanysPieShop/Properties/launchSettings.json`

### Problema: Errori di compilazione

**Soluzione:**
1. Pulisci la build: `dotnet clean`
2. Ripristina i pacchetti: `dotnet restore`
3. Ricompila: `dotnet build`

### Problema: Database non popolato

**Soluzione:** Il database viene popolato automaticamente all'avvio con dati di esempio. Se non vedi torte:
1. Elimina il database (file `.db` per SQLite o database LocalDB)
2. Riavvia l'applicazione

## Supporto Aggiuntivo

Per ulteriori informazioni:
- Consulta la **Guida Completa.pdf** inclusa nel repository
- Visita la documentazione ufficiale di ASP.NET Core: https://docs.microsoft.com/aspnet/core/
- Apri una issue su GitHub per problemi specifici

---

**Buon divertimento con Bethany's Pie Shop! 🥧**
