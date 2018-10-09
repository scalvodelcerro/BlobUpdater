Imports System.Data.Entity
Imports MySql.Data.EntityFramework

<DbConfigurationType(GetType(MySqlEFConfiguration))>
Public Class BlobUpdaterContext
  Inherits DbContext

  Public Property Actualizaciones As DbSet(Of Actualizacion)
  Public Property Aplicaciones As DbSet(Of Aplicacion)

  Public Sub New()
    MyBase.New()
    If Not Database.Exists() Then
      Database.Create()
    End If
  End Sub

  Protected Overrides Sub OnModelCreating(builder As DbModelBuilder)
    Dim entity As ModelConfiguration.EntityTypeConfiguration(Of Actualizacion) = builder.Entity(Of Actualizacion)
    Dim entityAplicacion As ModelConfiguration.EntityTypeConfiguration(Of Aplicacion) = builder.Entity(Of Aplicacion)
    entity.
      ToTable("adge_app_update").
      HasKey(Function(p) New With {p.Aplicacion, p.Version})
    entity.Property(Function(p) p.Aplicacion).
        HasColumnName("CDAPLICACION")
    entity.Property(Function(p) p.Fecha).
      HasColumnName("FECHA")
    entity.Property(Function(p) p.Version).
      HasColumnName("CDVERSION")
    entity.Property(Function(p) p.Contenido).
      HasColumnName("FILE_BLOB")

    entityAplicacion.
      ToTable("adge_aplicaciones").
      HasKey(Function(p) p.Nombre)
    entityAplicacion.Property(Function(p) p.Nombre).
      HasColumnName("CDAPLIC")

  End Sub

End Class
