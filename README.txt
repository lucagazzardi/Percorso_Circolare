# Percorso_Circolare

Progetto finale Percorso Circolare di Luca Gazzardi. Repository Git: https://github.com/lucagazzardi/Percorso_Circolare.git

## Setup dell'applicazione

Informazioni riguardo il funzionamento dell'applicazione.

### Database

Lo script per la creazione del database è presente sia nello ZIP inviato come allegato, sia nella repository Git.
La stringa di connessione presente all'interno dell'applicazione, per connettere Entity Framework al database, cerca il database **PercorsoCircolare**, sorgente: **(LocalDb)\MSSQLLocalDB**.

Il database è già popolato con alcuni dati inseriti durante i test.

### Solution

Per il debug dell'applicazione è necessario impostare il progetto **Circolare.WebAPI** e il progetto **Circolare.WEB** come **StartUp Projects** dalle properties della solution.

### Librerie da NPM

Sono state utilizzate diverse librerie di terze parti, scaricate tramite NPM all'interno del progetto **Circolare.WEB**.

All'interno di questa repository non viene copiata la cartella **node_modules**, pertanto è necessario eseguire il comando:

```
npm install
```

**IMPORTANTE**

Tra le altre, sarà presente la libreria typings per Bootstrap, all'interno della cartella **node_modules > @types > bootstrap** e la libreria Popper nella cartella **node_modules > popper.js**. All'interno del file **index.d.ts** della prima, alla **riga 9**, è presente un import della seconda, che dopo il download da NPM sarà scritto:

```
import * as Popper from "popper.js"
```

In questo stato la build della solution fallisce perchè il modulo non viene trovato da Visual Studio, quindi è necessario cambiare la riga sopra in questo modo:

```
import * as Popper from "popper.js/dist/popper"
```

E' consigliabile riavviare Visual Studio dopo il download dei pacchetti NPM e della modifica di cui sopra.

