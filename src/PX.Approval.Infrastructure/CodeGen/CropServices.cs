// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CropServices.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PX.Crop.GrpcApi {

  /// <summary>Holder for reflection information generated from CropServices.proto</summary>
  public static partial class CropServicesReflection {

    #region Descriptor
    /// <summary>File descriptor for CropServices.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CropServicesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJDcm9wU2VydmljZXMucHJvdG8SBGNyb3AaH2dvb2dsZS9wcm90b2J1Zi90",
            "aW1lc3RhbXAucHJvdG8iGwoHUmVxdWVzdBIQCgh1c2VyTmFtZRgBIAEoCSLA",
            "AgoWZ2V0YWN0aXZlY3JvcHZpZXdtb2RlbBIVCg1pbnRlZ3JhdGlvbklkGAEg",
            "ASgJEgwKBG5hbWUYAiABKAkSEwoLZGVzY3JpcHRpb24YAyABKAkSLwoLc3Rh",
            "cnRQZXJpb2QYBCABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wEi0K",
            "CWVuZFBlcmlvZBgFIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXAS",
            "NwoTc3RhcnRQbGFubmluZ1BlcmlvZBgGIAEoCzIaLmdvb2dsZS5wcm90b2J1",
            "Zi5UaW1lc3RhbXASNQoRZW5kUGxhbm5pbmdQZXJpb2QYByABKAsyGi5nb29n",
            "bGUucHJvdG9idWYuVGltZXN0YW1wEhwKFGlzR29hbFBsYW5uaW5nVmFsdWVk",
            "GAkgASgIIjcKCFJlc3BvbnNlEisKBWNyb3BzGAEgAygLMhwuY3JvcC5nZXRh",
            "Y3RpdmVjcm9wdmlld21vZGVsMkIKDENyb3BTZXJ2aWNlcxIyChFHZXRBbGxB",
            "Y3RpdmVDcm9wcxINLmNyb3AuUmVxdWVzdBoOLmNyb3AuUmVzcG9uc2VCEqoC",
            "D1BYLkNyb3AuR3JwY0FwaWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PX.Crop.GrpcApi.Request), global::PX.Crop.GrpcApi.Request.Parser, new[]{ "UserName" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PX.Crop.GrpcApi.getactivecropviewmodel), global::PX.Crop.GrpcApi.getactivecropviewmodel.Parser, new[]{ "IntegrationId", "Name", "Description", "StartPeriod", "EndPeriod", "StartPlanningPeriod", "EndPlanningPeriod", "IsGoalPlanningValued" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PX.Crop.GrpcApi.Response), global::PX.Crop.GrpcApi.Response.Parser, new[]{ "Crops" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The request message containing the user's name.
  /// </summary>
  public sealed partial class Request : pb::IMessage<Request>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Request> _parser = new pb::MessageParser<Request>(() => new Request());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Request> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PX.Crop.GrpcApi.CropServicesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Request() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Request(Request other) : this() {
      userName_ = other.userName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Request Clone() {
      return new Request(this);
    }

    /// <summary>Field number for the "userName" field.</summary>
    public const int UserNameFieldNumber = 1;
    private string userName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserName {
      get { return userName_; }
      set {
        userName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Request);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Request other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserName != other.UserName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (UserName.Length != 0) hash ^= UserName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (UserName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (UserName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (UserName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Request other) {
      if (other == null) {
        return;
      }
      if (other.UserName.Length != 0) {
        UserName = other.UserName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            UserName = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            UserName = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class getactivecropviewmodel : pb::IMessage<getactivecropviewmodel>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<getactivecropviewmodel> _parser = new pb::MessageParser<getactivecropviewmodel>(() => new getactivecropviewmodel());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<getactivecropviewmodel> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PX.Crop.GrpcApi.CropServicesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public getactivecropviewmodel() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public getactivecropviewmodel(getactivecropviewmodel other) : this() {
      integrationId_ = other.integrationId_;
      name_ = other.name_;
      description_ = other.description_;
      startPeriod_ = other.startPeriod_ != null ? other.startPeriod_.Clone() : null;
      endPeriod_ = other.endPeriod_ != null ? other.endPeriod_.Clone() : null;
      startPlanningPeriod_ = other.startPlanningPeriod_ != null ? other.startPlanningPeriod_.Clone() : null;
      endPlanningPeriod_ = other.endPlanningPeriod_ != null ? other.endPlanningPeriod_.Clone() : null;
      isGoalPlanningValued_ = other.isGoalPlanningValued_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public getactivecropviewmodel Clone() {
      return new getactivecropviewmodel(this);
    }

    /// <summary>Field number for the "integrationId" field.</summary>
    public const int IntegrationIdFieldNumber = 1;
    private string integrationId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string IntegrationId {
      get { return integrationId_; }
      set {
        integrationId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 3;
    private string description_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "startPeriod" field.</summary>
    public const int StartPeriodFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp startPeriod_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp StartPeriod {
      get { return startPeriod_; }
      set {
        startPeriod_ = value;
      }
    }

    /// <summary>Field number for the "endPeriod" field.</summary>
    public const int EndPeriodFieldNumber = 5;
    private global::Google.Protobuf.WellKnownTypes.Timestamp endPeriod_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp EndPeriod {
      get { return endPeriod_; }
      set {
        endPeriod_ = value;
      }
    }

    /// <summary>Field number for the "startPlanningPeriod" field.</summary>
    public const int StartPlanningPeriodFieldNumber = 6;
    private global::Google.Protobuf.WellKnownTypes.Timestamp startPlanningPeriod_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp StartPlanningPeriod {
      get { return startPlanningPeriod_; }
      set {
        startPlanningPeriod_ = value;
      }
    }

    /// <summary>Field number for the "endPlanningPeriod" field.</summary>
    public const int EndPlanningPeriodFieldNumber = 7;
    private global::Google.Protobuf.WellKnownTypes.Timestamp endPlanningPeriod_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp EndPlanningPeriod {
      get { return endPlanningPeriod_; }
      set {
        endPlanningPeriod_ = value;
      }
    }

    /// <summary>Field number for the "isGoalPlanningValued" field.</summary>
    public const int IsGoalPlanningValuedFieldNumber = 9;
    private bool isGoalPlanningValued_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsGoalPlanningValued {
      get { return isGoalPlanningValued_; }
      set {
        isGoalPlanningValued_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as getactivecropviewmodel);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(getactivecropviewmodel other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IntegrationId != other.IntegrationId) return false;
      if (Name != other.Name) return false;
      if (Description != other.Description) return false;
      if (!object.Equals(StartPeriod, other.StartPeriod)) return false;
      if (!object.Equals(EndPeriod, other.EndPeriod)) return false;
      if (!object.Equals(StartPlanningPeriod, other.StartPlanningPeriod)) return false;
      if (!object.Equals(EndPlanningPeriod, other.EndPlanningPeriod)) return false;
      if (IsGoalPlanningValued != other.IsGoalPlanningValued) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (IntegrationId.Length != 0) hash ^= IntegrationId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (startPeriod_ != null) hash ^= StartPeriod.GetHashCode();
      if (endPeriod_ != null) hash ^= EndPeriod.GetHashCode();
      if (startPlanningPeriod_ != null) hash ^= StartPlanningPeriod.GetHashCode();
      if (endPlanningPeriod_ != null) hash ^= EndPlanningPeriod.GetHashCode();
      if (IsGoalPlanningValued != false) hash ^= IsGoalPlanningValued.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (IntegrationId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(IntegrationId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Description);
      }
      if (startPeriod_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(StartPeriod);
      }
      if (endPeriod_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(EndPeriod);
      }
      if (startPlanningPeriod_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(StartPlanningPeriod);
      }
      if (endPlanningPeriod_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(EndPlanningPeriod);
      }
      if (IsGoalPlanningValued != false) {
        output.WriteRawTag(72);
        output.WriteBool(IsGoalPlanningValued);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (IntegrationId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(IntegrationId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Description);
      }
      if (startPeriod_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(StartPeriod);
      }
      if (endPeriod_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(EndPeriod);
      }
      if (startPlanningPeriod_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(StartPlanningPeriod);
      }
      if (endPlanningPeriod_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(EndPlanningPeriod);
      }
      if (IsGoalPlanningValued != false) {
        output.WriteRawTag(72);
        output.WriteBool(IsGoalPlanningValued);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (IntegrationId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(IntegrationId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (startPeriod_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(StartPeriod);
      }
      if (endPeriod_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EndPeriod);
      }
      if (startPlanningPeriod_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(StartPlanningPeriod);
      }
      if (endPlanningPeriod_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EndPlanningPeriod);
      }
      if (IsGoalPlanningValued != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(getactivecropviewmodel other) {
      if (other == null) {
        return;
      }
      if (other.IntegrationId.Length != 0) {
        IntegrationId = other.IntegrationId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.startPeriod_ != null) {
        if (startPeriod_ == null) {
          StartPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        StartPeriod.MergeFrom(other.StartPeriod);
      }
      if (other.endPeriod_ != null) {
        if (endPeriod_ == null) {
          EndPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        EndPeriod.MergeFrom(other.EndPeriod);
      }
      if (other.startPlanningPeriod_ != null) {
        if (startPlanningPeriod_ == null) {
          StartPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        StartPlanningPeriod.MergeFrom(other.StartPlanningPeriod);
      }
      if (other.endPlanningPeriod_ != null) {
        if (endPlanningPeriod_ == null) {
          EndPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        EndPlanningPeriod.MergeFrom(other.EndPlanningPeriod);
      }
      if (other.IsGoalPlanningValued != false) {
        IsGoalPlanningValued = other.IsGoalPlanningValued;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            IntegrationId = input.ReadString();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            Description = input.ReadString();
            break;
          }
          case 34: {
            if (startPeriod_ == null) {
              StartPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartPeriod);
            break;
          }
          case 42: {
            if (endPeriod_ == null) {
              EndPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndPeriod);
            break;
          }
          case 50: {
            if (startPlanningPeriod_ == null) {
              StartPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartPlanningPeriod);
            break;
          }
          case 58: {
            if (endPlanningPeriod_ == null) {
              EndPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndPlanningPeriod);
            break;
          }
          case 72: {
            IsGoalPlanningValued = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            IntegrationId = input.ReadString();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            Description = input.ReadString();
            break;
          }
          case 34: {
            if (startPeriod_ == null) {
              StartPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartPeriod);
            break;
          }
          case 42: {
            if (endPeriod_ == null) {
              EndPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndPeriod);
            break;
          }
          case 50: {
            if (startPlanningPeriod_ == null) {
              StartPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(StartPlanningPeriod);
            break;
          }
          case 58: {
            if (endPlanningPeriod_ == null) {
              EndPlanningPeriod = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EndPlanningPeriod);
            break;
          }
          case 72: {
            IsGoalPlanningValued = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class Response : pb::IMessage<Response>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Response> _parser = new pb::MessageParser<Response>(() => new Response());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PX.Crop.GrpcApi.CropServicesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response(Response other) : this() {
      crops_ = other.crops_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response Clone() {
      return new Response(this);
    }

    /// <summary>Field number for the "crops" field.</summary>
    public const int CropsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::PX.Crop.GrpcApi.getactivecropviewmodel> _repeated_crops_codec
        = pb::FieldCodec.ForMessage(10, global::PX.Crop.GrpcApi.getactivecropviewmodel.Parser);
    private readonly pbc::RepeatedField<global::PX.Crop.GrpcApi.getactivecropviewmodel> crops_ = new pbc::RepeatedField<global::PX.Crop.GrpcApi.getactivecropviewmodel>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::PX.Crop.GrpcApi.getactivecropviewmodel> Crops {
      get { return crops_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!crops_.Equals(other.crops_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= crops_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      crops_.WriteTo(output, _repeated_crops_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      crops_.WriteTo(ref output, _repeated_crops_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += crops_.CalculateSize(_repeated_crops_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Response other) {
      if (other == null) {
        return;
      }
      crops_.Add(other.crops_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            crops_.AddEntriesFrom(input, _repeated_crops_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            crops_.AddEntriesFrom(ref input, _repeated_crops_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
