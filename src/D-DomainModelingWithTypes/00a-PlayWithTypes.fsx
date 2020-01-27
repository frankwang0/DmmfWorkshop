﻿
// Use Record types for AND
type Name = {
  FirstName: string
  MiddleInitial: string
  LastName: string
}

// Use single case unions for wrapper types
type OrderId = OrderId of int

type Order = {
  OrderId : OrderId 
  // important:  types must be defined BEFORE they are referenced
  // (e.g. earlier in the file )
  OrderLines : OrderLine list //TODO define a type for OrderLine
}

// Use Choice types for OR
type PaymentMethod =
  | Cash
  | Card of CardInfo //TODO define a type for CardInfo
  | PayPal of EmailAddress //TODO define a type for EmailAddress

// Use Function types for workflows
type PlaceOrder =
  OrderForm -> OrderPlaced //TODO define a type for OrderForm and OrderPlaced


// =============================
// Constructing and Destructuring records
// =============================

// to create
let name = {FirstName="a"; MiddleInitial="b";LastName="c"}
// to extract
let first = name.FirstName

// =============================
// Constructing and Destructuring Choices
// =============================

// to create, use one of the cases as a function
let paymentMethod1 = Cash

let cardInfo = ??  //TODO Write some code to make this compile
let paymentMethod2 = Card cardInfo

let emailAddress = ??  //TODO Write some code to make this compile
let paymentMethod3 = PayPal emailAddress

// to destructure, use pattern matching
let printMethod paymentMethod =
  match paymentMethod with
  | Cash -> printfn "Cash"
  | Card cardInfo -> printfn "%A" cardInfo
  | PayPal emailAddress -> printfn "%A" emailAddress

paymentMethod1 |> printMethod

// =============================
// Constructing and Destructuring Single Choice Wrappers
// =============================

// to create, use the case as a function
let orderId = OrderId 99

// to deconstruct, there are a number of ways
// Approach 1: use pattern matching with one case
let value1 = 
    match orderId with
    | OrderId i -> i // return the inner value

// Approach 2: use pattern matching on the LEFT hand side
let (OrderId value2) = orderId 
// value2 is now 99

// Approach 3: in functions you can use the pattern matching directly in the parameter
let printOrderId (OrderId value) = 
    printfn "OrderId = %i" value

// test
printOrderId orderId   // output is "OrderId = 99"



// =============================
// Constructing Function types
// =============================

// To implement a function based on a function type
// 1.  define a value in the normal way, but use the function type as the type annotation
//     let placeOrder : PlaceOrder = ...
// 2.  for the implementation, use a lambda with however many parameters are needed.

// here's example of adding two numbers
type AddTwoNumbers = int -> int -> int  // the definition
let addTwoNumbers : AddTwoNumbers =  // the implementation
    fun n1 n2 -> 
        n1 + n2

// Now try to implement the PlaceOrder function type from above
let placeOrder : PlaceOrder =
  fun input ->
    let output = ?? //TODO create an OrderPlaced event value here
    output