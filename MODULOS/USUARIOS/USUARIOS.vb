Imports System.Data.SqlClient

Public Class USUARIOS
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()

    End Sub

    Private Sub USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel6.Visible = False
        MOSTRAR()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel6.Visible = True
        txtusuario.Clear()
        txtpassword.Clear()


    End Sub

    Private Sub GuardaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardaToolStripMenuItem.Click

        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@nombres", txtnombre.Text)
            cmd.Parameters.AddWithValue("@Login", txtusuario.Text)
            cmd.Parameters.AddWithValue("@password", txtpassword.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            MOSTRAR()
            Panel6.Visible = False

        Catch ex As Exception : MsgBox(ex.Message)

        End Try


    End Sub

    Sub MOSTRAR()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_usuario", conexion)
            da.Fill(dt)
            dataListado.DataSource = dt
            cerrar()
            multilinea(dataListado)
            dataListado.Columns(1).Visible = False

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged
        Focus()

    End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        Focus()
    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged
        Focus()

    End Sub


    Private Sub dataListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Panel6.Visible = True
            txtnombre.Text = dataListado.SelectedCells.Item(2).Value
            txtusuario.Text = dataListado.SelectedCells.Item(3).Value
            txtpassword.Text = dataListado.SelectedCells.Item(4).Value
            lblidusuario.Text = dataListado.SelectedCells.Item(1).Value
            GuardaToolStripMenuItem.Visible = False
            GuardarCambiosToolStripMenuItem.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click

        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idusuario", lblidusuario.Text)
            cmd.Parameters.AddWithValue("@nombres", txtnombre.Text)
            cmd.Parameters.AddWithValue("@Login", txtusuario.Text)
            cmd.Parameters.AddWithValue("@password", txtpassword.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            MOSTRAR()
            Panel6.Visible = False

        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dataListado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellContentClick
        If e.ColumnIndex = Me.dataListado.Columns.Item("Eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("Realmente desea eliminar este usuario?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try
                    Dim cmd As New SqlCommand
                    abrir()
                    cmd = New SqlCommand("eliminar_usuario", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@idusuario", dataListado.SelectedCells.Item(1).Value)
                    cmd.ExecuteNonQuery()
                    cerrar()
                    MOSTRAR()

                Catch ex As Exception : MsgBox(ex.Message)

                End Try

            Else
                MessageBox.Show("Cancelando eliminacion de registros?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End If


        End If
    End Sub
    Sub buscar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("buscar_usuarios", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@letra", txtBusca.Text)
            da.Fill(dt)
            dataListado.DataSource = dt
            cerrar()

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBusca.TextChanged
        buscar()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Visible = False

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@nombres", txtnombre.Text)
            cmd.Parameters.AddWithValue("@Login", txtLogin.Text)
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            MOSTRAR()
            Panel6.Visible = False

        Catch ex As Exception : MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub
End Class