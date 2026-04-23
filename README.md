# C# Banking Transaction System

## Problem Statement

This project simulates a Banking Transaction System using C# collections.
It manages accounts, processes transactions, prevents duplicates, and supports rollback functionality to maintain data consistency.

---

## Features

* Create and manage bank accounts
* Add and process transactions using FIFO queue
* Prevent duplicate transactions using HashSet
* Maintain transaction history
* Rollback last transaction using stack (LIFO)
* Display account balances and transaction records

---

## Technologies Used

* C#
* .NET
* Collections (List, Dictionary, Queue, Stack, HashSet)

---

## Data Structures Used

* **List<Transaction>** → Stores transaction history
* **Dictionary<string, double>** → Stores account balances
* **Queue<Transaction>** → Processes transactions (FIFO)
* **Stack<Transaction>** → Handles rollback (LIFO)
* **HashSet<string>** → Ensures unique transaction IDs

---

## Functionality Overview

### Account Management

* Create accounts with initial balance
* Prevent duplicate account creation

### Transaction Management

* Add transactions to queue
* Prevent duplicate transactions

### Processing Transactions

* Processes transactions in FIFO order
* Updates account balances
* Stores history and rollback data

### Rollback Feature

* Reverts the most recent transaction
* Updates balance and removes from history

---

## Sample Output

Account AliceSavings created with balance 5000

Account BobChecking created with balance 3000

Transaction SalaryCreditApril added to pending queue
Transaction RentPaymentApril added to pending queue
Transaction GroceryShopping added to pending queue
Duplicate transaction ID SalaryCreditApril detected. Ignored.

Transaction SalaryCreditApril processed for account AliceSavings, amount 2000
Transaction RentPaymentApril processed for account AliceSavings, amount -1500
Transaction GroceryShopping processed for account BobChecking, amount -300

Account Balances:
Account AliceSavings: Balance 5500
Account BobChecking: Balance 2700

Transaction History:
ID: SalaryCreditApril, Account: AliceSavings, Amount: 2000
ID: RentPaymentApril, Account: AliceSavings, Amount: -1500
ID: GroceryShopping, Account: BobChecking, Amount: -300

Transaction GroceryShopping rolled back for account BobChecking

Account Balances:
Account AliceSavings: Balance 5500
Account BobChecking: Balance 3000

Transaction History:
ID: SalaryCreditApril, Account: AliceSavings, Amount: 2000
ID: RentPaymentApril, Account: AliceSavings, Amount: -1500

---

## How to Run

1. Open the project in Visual Studio
2. Build the solution
3. Run the program (Ctrl + F5)

---

## Key Concepts

* C# Collections
* Data Structures
* FIFO (Queue) and LIFO (Stack)
* Transaction processing systems
* Data consistency using rollback
