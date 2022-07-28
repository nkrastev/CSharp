

// Bypass AutoPostBack="true" from asp:Listbox onChange

protected void lbEdit_Click(object sender, EventArgs e) {       
    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "let modal = new bootstrap.Modal(suppliersModal);modal.show();", true);
}
