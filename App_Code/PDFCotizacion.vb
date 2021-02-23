Imports System
Imports System.Data.SqlClient
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports MigraDoc.Rendering

Namespace tienda
	Public Class PDFCotizacion

#Region "Variables globales"
		Private document As Document
		Private addressFrame As TextFrame
		Private table As Table
		Private TableBorder As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(0, 0, 0)
		Private TableHeader As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(252, 241, 177)
		Private TableColumnaTotal As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)
		Private idIdioma As Integer = 1
#End Region

#Region "Constructores"
		Public Sub New()
		End Sub

		Public Sub New(ByVal claveIdioma As Integer)
			Me.idIdioma = claveIdioma
		End Sub
#End Region

		'Create a new MigraDoc document
		Public Function CreateDocument(ByVal claveOrden As Integer) As Document
			Dim objOrden As New Orden(claveOrden)

			Me.document = New Document()
			Me.document.Info.Title = "Cotización de productos para " & objOrden.nombre
			Me.document.Info.Subject = "Cotización de productos de todopromocional.com con fines informativos. Sujeta a cambios hasta el cierre de la orden"
			Me.document.Info.Author = "todopromocional.com"
			If objOrden.tempid <> String.Empty Then
				Dim objUser As New UserProfile(objOrden.tempid)
				If objUser.existe Then Me.document.Info.Author = objUser.nombre & " " & objUser.apellidos
			End If

			DefineStyles()
			CreatePage(objOrden)
			FillContent(objOrden)

			Return Me.document
		End Function

		'Defines the styles used to format the MigraDoc document.
		Private Sub DefineStyles()
			'Get the predefined style Normal.
			Dim estilo As Style = Me.document.Styles("Normal")

			'Because all styles are derived from Normal, the next line changes the 
			'font of the whole document. Or, more exactly, it changes the font of
			'all styles and paragraphs that do not redefine the font.
			estilo.Font.Name = "Verdana"

			estilo = Me.document.Styles(StyleNames.Header)
			estilo.ParagraphFormat.AddTabStop("16.5cm", TabAlignment.Right)

			estilo = Me.document.Styles(StyleNames.Footer)
			estilo.ParagraphFormat.AddTabStop("8.2cm", TabAlignment.Center)

			'Create a new style called Table based on style Normal
			estilo = Me.document.Styles.AddStyle("Table", "Normal")
			estilo.Font.Name = "Verdana"
			estilo.Font.Name = "Times New Roman"
			estilo.Font.Size = 9

			'Create a new style called Reference based on style Normal
			estilo = Me.document.Styles.AddStyle("Reference", "Normal")
			'estilo.ParagraphFormat.SpaceBefore = "5mm"
			'estilo.ParagraphFormat.SpaceAfter = "5mm"
			estilo.ParagraphFormat.TabStops.AddTabStop("16.5cm", TabAlignment.Right)
		End Sub

		'Creates the static parts of the invoice
		Private Sub CreatePage(ByRef objOrden As Orden)
			'Each MigraDoc document needs at least one section.
			Dim section As Section = Me.document.AddSection()
			section.PageSetup.PageFormat = PageFormat.Letter

			'Put a logo in the header
			Dim image As Image = section.Headers.Primary.AddImage(ConfigurationManager.AppSettings("files") & "productos\images\banner.jpg")
			image.Height = "2.5cm"
			image.LockAspectRatio = True
			image.RelativeVertical = RelativeVertical.Line
			image.RelativeHorizontal = RelativeHorizontal.Margin
			image.Top = ShapePosition.Top
			image.Left = ShapePosition.Right
			image.WrapFormat.Style = WrapStyle.Through

			'Create footer
			Dim paragraph As Paragraph = section.Footers.Primary.AddParagraph()
			paragraph.Format.Font.Size = 9
			paragraph.Format.Alignment = ParagraphAlignment.Center
			paragraph.AddText("Todopromocional.com - Monterrey, NL, Mex")
			paragraph.AddLineBreak()
			paragraph.AddText("Teléfono 55-55-55555555 - Email: aaaaaa@todopromocional.com - xxxxxxxxxxxxxxxxxxx")

			'Create the text frame for the address
			Me.addressFrame = section.AddTextFrame()
			Me.addressFrame.Height = "1.5cm"
			Me.addressFrame.Width = "7.0cm"
			Me.addressFrame.Left = ShapePosition.Left
			Me.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin
			Me.addressFrame.Top = "5.0cm"
			Me.addressFrame.RelativeVertical = RelativeVertical.Page

			'Put sender in address frame
			paragraph = Me.addressFrame.AddParagraph(objOrden.nombreE)
			paragraph.AddLineBreak()
			paragraph.AddText(objOrden.NombreEmpresa)
			paragraph.Format.Font.Name = "Times New Roman"
			paragraph.Format.Font.Size = 11
			paragraph.Format.SpaceAfter = 2

			'Add the print date field
			paragraph = section.AddParagraph()
			paragraph.Format.SpaceBefore = "4cm"
			paragraph.Style = "Reference"
			paragraph.AddFormattedText("COTIZACIÓN", TextFormat.Bold)
			paragraph.AddTab()
			paragraph.AddText("Monterrey, México, ")
			paragraph.AddDateField("d \de MMMM \de yyyy")

			'Create the item table
			Me.table = section.AddTable()
			Me.table.Style = "Table"
			Me.table.Borders.Color = TableBorder
			Me.table.Borders.Width = 0.25
			Me.table.Borders.Left.Width = 0.5
			Me.table.Borders.Right.Width = 0.5
			Me.table.Rows.LeftIndent = 0

			'Before you can add a row, you must define the columns
			Dim column As Column = Me.table.AddColumn("6cm")	'clave, nombre, color, servicios
			column.Format.Alignment = ParagraphAlignment.Left

			column = Me.table.AddColumn("2cm")		'Costo unitario
			column.Format.Alignment = ParagraphAlignment.Right

			column = Me.table.AddColumn("2cm")		'Cantidad
			column.Format.Alignment = ParagraphAlignment.Right

			column = Me.table.AddColumn("2cm")		'Costo producto
			column.Format.Alignment = ParagraphAlignment.Right

			column = Me.table.AddColumn("2cm")		'Costo impresion
			column.Format.Alignment = ParagraphAlignment.Right

			column = Me.table.AddColumn("2.5cm")		'Total
			column.Format.Alignment = ParagraphAlignment.Right

			'Create the header of the table
			Dim row As Row = table.AddRow()
			row.HeadingFormat = True
			row.VerticalAlignment = VerticalAlignment.Bottom
			row.Format.Alignment = ParagraphAlignment.Center
			row.Format.Font.Bold = True
			row.Shading.Color = TableHeader

			row.Cells(0).AddParagraph("Producto")
			row.Cells(1).AddParagraph("Precio unitario")
			row.Cells(2).AddParagraph("Cantidad")
			row.Cells(3).AddParagraph("Costo producto")
			row.Cells(4).AddParagraph("Costo impresión")
			row.Cells(5).AddParagraph("Total")

			row.Cells(0).Format.Alignment = ParagraphAlignment.Left

			Me.table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.25)
		End Sub

		'Creates the dynamic parts of the invoice.
		Private Sub FillContent(ByRef objOrden As Orden)
			Dim objEstadoEnvio As New EstadoIdioma(objOrden.idEstadoE, Me.idIdioma)
			Dim paragraph As Paragraph

			'Iterate the invoice items
			Dim dr As SqlDataReader = New OrdenDetalle().getDR(objOrden.idOrden)
			Do While dr.Read
				Dim objProductoIdioma As New ProductoIdioma(CInt(dr("idProducto")), Me.idIdioma)
				Dim cantidad As Integer = dr("cantidad")
				Dim costoUnitario As Decimal = dr("costoUnitario")
				Dim descuento As Decimal = dr("descuento")
				Dim totalProductos As Decimal = dr("total")
				Dim totalServicios As Decimal = 0
				Dim nombreColor As String = New Codigocolor().GetNombre(dr("color"), Me.idIdioma)

				Dim datRow As Row = Me.table.AddRow()
				datRow.TopPadding = 1.5
				datRow.VerticalAlignment = VerticalAlignment.Top

				paragraph = datRow.Cells(0).AddParagraph
				paragraph.AddText(objProductoIdioma.clave & ", " & objProductoIdioma.nombre)
				paragraph.AddText(", " & nombreColor.ToUpper)

				Dim drServicios As SqlDataReader = New OrdendetalleProductoServicio().GetServiciosCotizados(CInt(dr("idOrdendetalle")), Me.idIdioma)
				If drServicios.HasRows Then
					paragraph.AddLineBreak()
					paragraph.AddSpace(3)
					paragraph.AddText("Impresión: ")
					Do While drServicios.Read
						paragraph.AddText(drServicios("nombre") & " " & drServicios("CantidadComponenteBase") & " " & drServicios("componenteBase") & ". ")
						totalServicios = totalServicios + CDec(dr("total"))
					Loop
				End If
				drServicios.Close()

				datRow.Cells(1).AddParagraph(costoUnitario.ToString("#,##0.00"))
				datRow.Cells(2).AddParagraph(cantidad)
				datRow.Cells(3).AddParagraph(totalProductos.ToString("#,##0.00"))
				datRow.Cells(4).AddParagraph(totalServicios.ToString("#,##0.00"))
				datRow.Cells(5).AddParagraph((totalProductos + totalServicios).ToString("#,##0.00"))

				datRow.Cells(5).Shading.Color = TableColumnaTotal
				Me.table.SetEdge(0, Me.table.Rows.Count - 1, 6, 1, Edge.Box, BorderStyle.Single, 0.25)
			Loop
			dr.Close()

			'Add an invisible row as a space line to the table
			Dim row As Row = Me.table.AddRow()
			row.Borders.Visible = False

			'Add the totales
			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Productos")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(objOrden.subtotal.ToString("#, ##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Servicios de impresión")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(objOrden.costoAdicional.ToString("#,##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Manejo y envío")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(objOrden.costoEnvio.ToString("#,##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Descuento")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph("-" & objOrden.descuento.ToString("#,##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			Dim totalAntesImpuesto As Decimal = objOrden.subtotal + objOrden.costoAdicional + objOrden.costoEnvio - objOrden.descuento
			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Subtotal")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(totalAntesImpuesto.ToString("#,##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			Dim impuesto As Decimal = objEstadoEnvio.impuesto
			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("Impuesto (" & impuesto & "%)")
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(objOrden.impuesto.ToString("#,##0.00"))
			row.Cells(5).Shading.Color = TableColumnaTotal

			row = Me.table.AddRow()
			row.Cells(0).Borders.Visible = False
			row.Cells(0).AddParagraph("TOTAL")
			row.Cells(0).Format.Font.Bold = True
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 4
			row.Cells(5).AddParagraph(objOrden.total.ToString("c"))
			row.Cells(5).Shading.Color = TableColumnaTotal
			row.Cells(5).Format.Font.Bold = True

			'Set the borders of the specified cell range
			Me.table.SetEdge(5, Me.table.Rows.Count - 7, 1, 7, Edge.Box, BorderStyle.Single, 0.5, MigraDoc.DocumentObjectModel.Color.Empty)

			'Add the notes paragraph
			paragraph = Me.document.LastSection.AddParagraph()
			paragraph.AddFormattedText("Observaciones:", TextFormat.Bold)
			paragraph.Format.SpaceBefore = "0.5cm"
			paragraph.Format.Borders.Width = 0.5
			paragraph.Format.Borders.Distance = 3
			paragraph.Format.Borders.Color = TableBorder
			paragraph.Format.Shading.Color = TableHeader
			paragraph.AddLineBreak()
			paragraph.AddSpace(5)
			paragraph.AddText(objOrden.Condiciones)
		End Sub
	End Class
End Namespace
