# InvoiceMaker

## Project Structure
This solution consist of 2 project
```
|-InvoiceMaker (contains code of the Backend)
|-InvoiceMakerFrontend (contains code of the Frontend)
```

## Data Model
Data Model of this solution is explained below
```
Language
- ID [int]
- name [string]

Currency
- ID [int]
- name [string]
- description [string]

UnitMeasurement
- ID [int]
- name [string]

PurchaseOrder
- ID [int]
- no [string]
- name [string]

Company
- ID [int]
- name [string]
- logo [string]
- address [string]

Items
- ID [int]
- invoice [Invoice]
- name [string]
- quantity [double]
- rate [double] 
- amount [double]
- unit [UnitMeasurement]

Invoice
- ID [int]
- from [string]
- to [Company]
- discountName [string]
- discountAmount [double]
- invoiceDate [datetime]
- invoiceDue [datetime]
- purchaseOrder [PurchaseOrder]
- language [Language]
- currency [Currency]
```

## Before Run App
1. Fix database password inside `/InvoiceMaker/appsettings.json`

## Note
1. Frontend project haven't been worked on