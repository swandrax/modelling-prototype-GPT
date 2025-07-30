let checkPromptLoop (iterations: int) =
    if iterations > 1000 then
        failwith "[SIGMA] Loop exceeds safe threshold"

let validateRLHF model =
    match model.Overfit with
    | true -> Some("SIGMA: RLHF is overclocked")
    | false -> None
let synchronizeModel model =
    if model.SyncRequired then
        Some("SIGMA: Model synchronization required")
    else
        None
let validateModel model =
    let loopCheck = checkPromptLoop model.Iterations
    let rlhfCheck = validateRLHF model
    let syncCheck = synchronizeModel model
    loopCheck @ rlhfCheck @ syncCheck

let throwIfInvalid model =
    let errors = validateModel model
    match errors with
    | [] -> ()
    | _ -> raise (InvalidModelException (String.concat "\n" errors))
exception InvalidModelException of string