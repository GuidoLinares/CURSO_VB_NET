Module tamaño_automatico_de_datatables
    Public Sub multilinea(ByRef list As DataGridView)
        list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        list.ColumnHeadersDefaultCellStyle.Alignment = New DataGridViewContentAlignment
        list.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        list.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        list.EnableHeadersVisualStyles = False
        Dim stycabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        stycabeceras.BackColor = Color.White
        stycabeceras.ForeColor = Color.Black
        stycabeceras.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
        list.ColumnHeadersDefaultCellStyle = stycabeceras

    End Sub
End Module
