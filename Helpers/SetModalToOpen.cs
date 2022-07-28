/*
<script type="text/javascript">
    function openModal() {
        $('#myModal').modal('show');
    }
</script>
*/

// Bypass AutoPostBack="true" from asp:Listbox onChange

protected void lbEdit_Click(object sender, EventArgs e) {   
      ScriptManager.RegisterStartupScript(this,this.GetType(),"Pop", "openModal();", true);
}
