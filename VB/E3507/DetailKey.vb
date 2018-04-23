Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace E1271
	Public Class DetailKey
		Public Sub New(ByVal _masterRowHandle As Integer, ByVal _relationIndex As Integer)
			MasterRowHandle = _masterRowHandle
			RelationIndex = _relationIndex
		End Sub
		Private privateMasterRowHandle As Integer
		Public Property MasterRowHandle() As Integer
			Get
				Return privateMasterRowHandle
			End Get
			Set(ByVal value As Integer)
				privateMasterRowHandle = value
			End Set
		End Property
		Private privateRelationIndex As Integer
		Public Property RelationIndex() As Integer
			Get
				Return privateRelationIndex
			End Get
			Set(ByVal value As Integer)
				privateRelationIndex = value
			End Set
		End Property
		Public Overrides Function GetHashCode() As Integer
			Return MasterRowHandle.GetHashCode() Xor RelationIndex.GetHashCode()
		End Function
		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			If TypeOf obj Is DetailKey Then
				Return (CType(obj, DetailKey)).MasterRowHandle = MasterRowHandle AndAlso (CType(obj, DetailKey)).RelationIndex = RelationIndex
			End If
			Return MyBase.Equals(obj)
		End Function
	End Class
End Namespace
