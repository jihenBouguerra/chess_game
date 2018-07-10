<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionCompte
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListeCompte = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(365, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 29)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Supprimer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(365, 103)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 29)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Rendre Administrateur "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListeCompte
        '
        Me.ListeCompte.FormattingEnabled = True
        Me.ListeCompte.Location = New System.Drawing.Point(26, 25)
        Me.ListeCompte.Name = "ListeCompte"
        Me.ListeCompte.Size = New System.Drawing.Size(306, 199)
        Me.ListeCompte.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(365, 155)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Voir Historiques"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GestionCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 261)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListeCompte)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "GestionCompte"
        Me.Text = "Gestion Comptes"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListeCompte As ListBox
    Friend WithEvents Button3 As Button
End Class
