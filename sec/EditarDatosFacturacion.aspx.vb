
Partial Class sec_EditarDatosFacturacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LlenaDrops()
            Llenado()
        End If
    End Sub

    Private Sub LlenaDrops()



        Dim mylistitem As New ListItem("Selecciona una opcion", "")

        Dim myce As New tienda.CatalogoEntidad



        Dim mycm As New tienda.CatalogoMunicipio





        dropEstadosF.DataSource = myce.GetDS(1)
        dropEstadosF.DataValueField = "ClaveEntidad"
        dropEstadosF.DataTextField = "NombreEntidad"
        dropEstadosF.DataBind()
        dropEstadosF.Items.Insert(0, mylistitem)

        drpMunicipiosF.DataSource = mycm.GetDS(CInt(dropEstadosF.Items(1).Value))
        drpMunicipiosF.DataValueField = "NombreMunicipio"
        drpMunicipiosF.DataTextField = "NombreMunicipio"
        drpMunicipiosF.DataBind()
        drpMunicipiosF.Items.Insert(0, mylistitem)




        Dim mylContado As New ListItem("Contado", "0")
        Dim mylCreditoSuper As New ListItem("Credito", "1")
        Dim mylCredito As New ListItem("Precredito", "3")




    End Sub

    Private Sub Llenado()
        Dim idOrden As Integer = CInt(Request("idOrden"))


        If idOrden > 0 Then
            Dim objOrden As New tienda.Orden(idOrden)
            If Not objOrden.existe Then Response.Redirect("~/logout.aspx")

            If objOrden.idUserProfile <> CInt(Session("idUserProfile")) Then Response.Redirect("~/logout.aspx")


            litNumOrden.Text = objOrden.idOrden

            Dim mycm As New tienda.CatalogoMunicipio




            txtNombreF.Text = objOrden.nombreF
                txtRFC.Text = objOrden.rfc
                txtDireccionF.Text = objOrden.direccionF
            txtColoniaF.Text = objOrden.ColoniaF
            txtCiudadF.Text = objOrden.ciudadF

                dropEstadosF.SelectedValue = objOrden.idEstadoF
                If objOrden.idEstadoF > 0 Then
                    drpMunicipiosF.DataSource = mycm.GetDS(objOrden.idEstadoF)
                    drpMunicipiosF.DataValueField = "NombreMunicipio"
                    drpMunicipiosF.DataTextField = "NombreMunicipio"
                    drpMunicipiosF.DataBind()
                End If


            drpMunicipiosF.SelectedValue = objOrden.MunicipioF
            hdMunicipioF.Value = objOrden.MunicipioF

            txtcpF.Text = objOrden.cpF
            txtTelefonoF.Text = objOrden.telefonoF



            txtNumeroEF.Text = objOrden.NumeroEF
            txtNumeroIF.Text = objOrden.NumeroIF
            txtColoniaF.Text = objOrden.ColoniaF
            txtReferenciaF.Text = objOrden.ReferenciaF




            txtClaveBancaria.Text = objOrden.claveBancaria



            If objOrden.tempid <> "" Then
                    Dim myvendedorAsignado As New tienda.UserProfile(CInt(objOrden.tempid))
                    lblVendedorAsignado.Text = myvendedorAsignado.nombre & " " & myvendedorAsignado.apellidos
                    hdVendedorAsignado.Value = objOrden.tempid

                    Dim myrfc As New Facturitas.RFC(objOrden.rfc)
                    If myrfc.VendedorAsignado <> objOrden.tempid Then
                        myvendedorAsignado = New tienda.UserProfile(myrfc.VendedorAsignado)
                        lblVendedorAsignado.Text = myvendedorAsignado.nombre & " " & myvendedorAsignado.apellidos
                        hdVendedorAsignado.Value = myrfc.VendedorAsignado
                    End If

                End If






            txtincluirobservacionfactura.Text = objOrden.IncluirObservacionFactura

            'ocultar boton en caso de estar pagada 
            Dim myf As New Facturitas.Comprobante
            Dim totalfacturas As Decimal = myf.GetTotalComprobantesOrden(objOrden.idOrden)

            If totalfacturas >= objOrden.total - 5 Then
                btnEditar.Visible = False
            Else
                btnEditar.Visible = True
            End If



        End If

    End Sub





    Protected Sub dropEstadosF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropEstadosF.SelectedIndexChanged


        Dim mycm As New tienda.CatalogoMunicipio

        drpMunicipiosF.DataSource = mycm.GetDS(CInt(dropEstadosF.SelectedValue))
        drpMunicipiosF.DataValueField = "NombreMunicipio"
        drpMunicipiosF.DataTextField = "NombreMunicipio"
        drpMunicipiosF.DataBind()


    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If Request("regreso") = "vercompras" Then
            Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
        End If
        Response.Redirect("SolicitarFactura.aspx?idOrden=" & Request("idOrden"))
    End Sub
    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Page.IsValid Then
            Dim myo As New tienda.Orden(CInt(Request("idOrden")))
            myo.rfc = txtRFC.Text
            myo.nombreF = txtNombreF.Text
            myo.direccionF = txtDireccionF.Text
            myo.NumeroEF = txtNumeroEF.Text
            myo.NumeroIF = txtNumeroIF.Text
            myo.ColoniaF = txtColoniaF.Text
            myo.idEstadoF = dropEstadosF.SelectedValue
            myo.MunicipioF = drpMunicipiosF.SelectedValue
            myo.ciudadF = txtCiudadF.Text
            myo.ReferenciaF = txtReferenciaF.Text
            myo.cpF = txtcpF.Text
            myo.telefonoF = txtTelefonoF.Text
            myo.claveBancaria = txtClaveBancaria.Text
            myo.IncluirObservacionFactura = txtincluirobservacionfactura.Text
            myo.Update()




            If Request("regreso") = "vercompras" Then
                Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
            End If


            Response.Redirect("SolicitarFactura.aspx?idOrden=" & Request("idOrden"))



        End If
    End Sub
End Class
