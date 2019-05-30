#if !FAKE
// Required to make VS Code intellisense happy --GB
#r "netstandard"
#load "./.fake/build.fsx/intellisense.fsx"
#endif

// When running partial targets (such as BuildTradeUploads.Console)
// FAKE DSL shows the warning about not matching rules.
// Yes, but for partial builds the rest is irrelevant, therefore
// disabling this warning code... --GB
#nowarn "0026"
