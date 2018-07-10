<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuAdmin
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GestionComteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionHistoriqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeconnexionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionComteToolStripMenuItem, Me.GestionHistoriqueToolStripMenuItem, Me.ParametresToolStripMenuItem, Me.DeconnexionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(585, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GestionComteToolStripMenuItem
        '
        Me.GestionComteToolStripMenuItem.Name = "GestionComteToolStripMenuItem"
        Me.GestionComteToolStripMenuItem.Size = New System.Drawing.Size(105, 20)
        Me.GestionComteToolStripMenuItem.Text = "Gestion Compte"
        '
        'GestionHistoriqueToolStripMenuItem
        '
        Me.GestionHistoriqueToolStripMenuItem.Name = "GestionHistoriqueToolStripMenuItem"
        Me.GestionHistoriqueToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.GestionHistoriqueToolStripMenuItem.Text = "Gestion Historique"
        '
        'ParametresToolStripMenuItem
        '
        Me.ParametresToolStripMenuItem.Name = "ParametresToolStripMenuItem"
        Me.ParametresToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.ParametresToolStripMenuItem.Text = "Parametres"
        '
        'DeconnexionToolStripMenuItem
        '
        Me.DeconnexionToolStripMenuItem.Name = "DeconnexionToolStripMenuItem"
        Me.DeconnexionToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.DeconnexionToolStripMenuItem.Text = "Deconnexion"
        '
        'MenuAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 381)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuAdmin"
        Me.Text = "Administrateur"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GestionComteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestionHistoriqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParametresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeconnexionToolStripMenuItem As ToolStripMenuItem
End Class
