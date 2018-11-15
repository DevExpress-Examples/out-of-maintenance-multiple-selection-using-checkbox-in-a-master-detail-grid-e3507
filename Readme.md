<!-- default file list -->
*Files to look at*:

* [CheckMarkSelection.cs](./CS/E3507/CheckMarkSelection.cs) (VB: [CheckMarkSelection.vb](./VB/E3507/CheckMarkSelection.vb))
* [DataSet1.cs](./CS/E3507/DataSet1.cs) (VB: [DataSet1.vb](./VB/E3507/DataSet1.vb))
* [DetailKey.cs](./CS/E3507/DetailKey.cs) (VB: [DetailKey.vb](./VB/E3507/DetailKey.vb))
* [Form1.cs](./CS/E3507/Form1.cs) (VB: [Form1.vb](./VB/E3507/Form1.vb))
* [Program.cs](./CS/E3507/Program.cs) (VB: [Program.vb](./VB/E3507/Program.vb))
<!-- default file list end -->
# Multiple selection using checkbox in a Master-Detail grid


<p>The following example shows how to implement multiple selection in case of a web style (via check boxes) in a <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument783"><u>Master-Detail</u></a>. This example is created based on the <a href="https://www.devexpress.com/Support/Center/p/E1271">Multiple selection using checkbox (web style)</a> example.<br> The main specifics of operating detail views is that each detail view is a <strong>clone</strong> of a detail "<strong>pattern</strong>" View, which serves as a template for creating clones. Detail clones only exist when master rows are expanded. Therefore, you cannot customize each detail clone at design time, and in most cases this is unnecessary. Instead, you can customize the detail "<strong>pattern</strong>" View. The <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument780"><u>Pattern and Clone Views</u></a> article describe this behavior in greater detail.</p>
<p>The <strong>GridCheckMarksSelection</strong> helper class contains all code related to the selection. To implement the selection in a grid, attach its main view to a helper class instance.<br><br><em>Note: This solution is applicable for a two-level grid: MainView - DetailViews</em></p>
<p><strong>See Also:<br> </strong><a href="https://www.devexpress.com/Support/Center/p/E990">How to use an unbound check box column to select grid rows</a><br> <a href="https://www.devexpress.com/Support/Center/p/E1271">Multiple selection using checkbox (web style)</a><br> <a href="https://www.devexpress.com/Support/Center/p/A371">How to select rows via an unbound checkbox column</a></p>

<br/>


