### Background
- DALi에서는 내부적으로 DALi object를 소유한 Handle 객체가 존재하며, 해당 객체는 Stack에 할당되어 임시적으로 생성되고 소멸됨
- 해당 Handle로 객체의 생성 및 소멸 관리 책임은 Managed(C#)에 있음

### Tizen.UI 방법
- [SafeHandle](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.safehandle?view=net-7.0)기반 p/Invoke 및 Handle 관리
  - 리소스가 더이상 사용되지 않을 때 자동으로 해제하여, 메모리 누수 방지
- SafeHandle로 관리 하지 않는 경우
  - 명시적으로 New를 요청하여 받은 IntPtr
  - View와 같이 UI thread에서만 생성/삭제되어야 하는 경우 (SafeHandle의 경우 GC에 의해 gc thread에서 삭제될수 있음)
###### SafeHandle 구현 예
```cs
 public class Vector3Handle : SafeHandle
 {
     public Vector3Handle() : base(IntPtr.Zero, true)
     {
     }

     public override bool IsInvalid => handle == IntPtr.Zero;

     protected override bool ReleaseHandle()
     {
         Interop.Vector3.DeleteVector3(handle);
         SetHandle(IntPtr.Zero);
         return true;
     }
```

###### SafeHandle 사용 예
```cs
  public class View
  {
    //...
    public Size CurrentSize
    {
      get
      {
        using var vector3 = ObjectPool.NewVector3();
        Interop.ActorInternal.RetrieveCurrentPropertyVector3(Handle, DaliPropertyKey.View.SIZE, vector3);
        return new Size(Interop.Vector3.XGet(vector3), Interop.Vector3.YGet(vector3));
      }
    }
   //...
 }
```


### Why SafeHandle ?
- .NET Framework 지침에서 HandleRef를 SafeHandle기반으로 교체하라고 가이드하고 있음.
  > ℹ️ [**Important**](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.handleref?view=net-7.0#remarks)
  >
  > Starting with the .NET Framework 2.0, the functionality of the [HandleRef](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.handleref?view=net-7.0) class has been replaced by the [SafeHandle](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.safehandle?view=net-7.0) class and its derived classes, as well as by the [CriticalHandle](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.criticalhandle?view=net-7.0) class.
- ChatGPT
  > C#에서 HandleRef 대신 SafeHandle을 사용해야 하는 이유는 다음과 같습니다.
  > 1. **안전성**:
  > 메모리 누수 방지: SafeHandle은 가비지 컬렉션 중에 자동으로 리소스를 해제하기 때문에 메모리 누수를 방지합니다. HandleRef은 개발자가 직접 리소스 해제를 처리해야 하므로 누수 발생 가능성이 높습니다.
  > Dangling Pointer 방지: SafeHandle은 핸들이 유효하지 않게 된 후 사용되는 것을 방지하여 dangling pointer 문제를 해결합니다. HandleRef는 이러한 보호 기능을 제공하지 않습니다.
  > 2. **사용 편의성**:
  > 자동 리소스 관리: SafeHandle은 리소스 해제를 자동으로 처리하므로 개발자가 직접 관리할 필요가 없어 코드가 간결해지고 유지 관리가 쉬워집니다.
  > 파생 클래스: 특정 리소스 유형에 맞는 동작을 구현하는 SafeHandle의 파생 클래스를 만들 수 있습니다. 예를 들어, SafeFileHandle은 파일 핸들에 대한 특수 기능을 제공합니다.
  > 3. **보안**:
  > 핸들 재사용 방지: SafeHandle은 리소스가 해제된 후 핸들이 재사용되는 것을 방지하여 보안 취약점을 줄입니다. HandleRef는 이러한 보호 기능을 제공하지 않습니다.
  > 4. **성능**:
  > 최적화된 리소스 관리: SafeHandle은 리소스 관리를 위해 최적화되어 있어 HandleRef보다 성능이 뛰어날 수 있습니다.
  > 5. **플랫폼 호환성**:
  > 다양한 플랫폼 지원: SafeHandle은 다양한 플랫폼에서 안전하고 효율적인 리소스 관리를 제공합니다.
  >
  > 결론적으로, SafeHandle은 HandleRef보다 안전하고 사용하기 쉬우며 다양한 기능을 제공하기 때문에 C#에서 네이티브 리소스를 관리하는 데 선호되는 방법입니다.