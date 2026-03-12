### Background
- DALi에서는 primitive type이 아닌 다양한 class 데이터 객체를 사용
- 해당 데이터 객체를 Native와 Managed(C#)에서 관리를 해야함

이름 | 구성 요소
-- | --
Dali::Property::Value | union { primitive type,vectorXMatrix,Rect<>,Quaternion,AngleAxis,PropertyMap,}
Dali:Property::Map | array {  Proeprty::Value ...}
Matrix | float [16]
Matrix3 | float  [9]
Quaternion | vector 4
Vector2 | float [2]
Vector3 | float [3]
Vector4 / Color | float [4]


### Tizen.UI 방법
- Native와 Managed(C#) 데이터 객체를 독립적으로 분리함
- C#에서의 데이터 객체는 모두 struct로 표현하여 Value객체로 Heap에 저장되지 않도록 함.
- 이로 인해, C#에서 빈번하게 데이터 객체를 생성/삭제하더라도 Native Call이 필요하지 않으며 불필요한 Native 객체 생성 유발하지 않음

Legacy (Tizen.NUI) | New (Tizen.UI)
--- | --- 
class `Size2D` | struct `Size` | 
class `Position` | struct `Point` | 
class `Position2D` | struct `Point` |
class `Color` | struct `Color` | 
class `Vector2` | struct `Point`
class `Vector3` | struct `Size` or struct `Point`
class `Vector4` | struct `CornerRadius`
class `Extents` | struct `Thickness`| 
class `Rectangle` | struct `Rect`

```cs
public struct Size
{
    public static readonly Size Zero;

    public Size(float width, float height)
    {
        if (float.IsNaN(width))
            throw new ArgumentException("NaN is not a valid value for width");
        if (float.IsNaN(height))
            throw new ArgumentException("NaN is not a valid value for height");
        _width = width;
        _height = height;
    }
//...
```

#### C#에서 Native 로 데이터 객체 전달 방법
- C# struct를 Native 객체로 변환하여 전달함
- C#에서 Native로 데이터를 보낼 때 임시적으로 Native 객체가 생성되고, 이렇게 생성된 Native 객체에 데이터를 설정하여 Native API를 호출함
- Native임시 객체를 생성할때마다 이에 대응되는 C#객체를 생성하여 이를 관리함
- Interop API가 primitive type으로 펼쳐진 경우에는 native 임시 객체 생성이 필요 없음
###### Managed (C#) 코드
```cs
public class View
{
//...
  public Thickness TouchEdgeInsets
  {
    get
    {
        Interop.ActorInternal.GetTouchAreaOffset(Handle, out int left, out int right, out int bottom, out int top);
        NativeHandleExtensions.CheckException();
        return new Thickness(-left, right, -top, bottom);
    }
    set
    {
        Interop.ActorInternal.SetTouchAreaOffset(Handle, (int)-value.Left, (int)value.Right, (int)value.Bottom, (int)-value.Top);
        NativeHandleExtensions.CheckException();
    }
  }
//...
}

// Interop APIs
[DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_DevelActor_Property_SetTouchAreaOffset")]
public static extern void SetTouchAreaOffset(IntPtr jarg1, int jarg2, int jarg3, int jarg4, int jarg5);
```
###### Native 코드
```cpp
SWIGEXPORT void SWIGSTDCALL CSharp_DevelActor_Property_SetTouchAreaOffset(void* jarg1, int jarg2, int jarg3, int jarg4, int jarg5)
{
  Dali::Actor* arg1 = (Dali::Actor*)0;
  arg1              = (Dali::Actor*)jarg1;
  Rect<int> arg2    = Rect(jarg2, jarg3, jarg4, jarg5);
  {
    try
    {
      (arg1)->SetProperty(Dali::DevelActor::Property::TOUCH_AREA_OFFSET, arg2);
    }
    CALL_CATCH_EXCEPTION();
  }
}
```

#### C# 데이터 객체를 Native 객체로 변환하는 방법
- Native 임시 객체를 IDisposable 객체로 대응하여 관리
- using을 사용하여 native객체를 Interop호출이 발생하는 해당 stack에서만 유효하도록 함 
  - 하지만, heap객체이므로 C#객체는 GC전까지 유지됨

```cs
public class View
{
//...
        public Size NaturalSize
        {
            get
            {
                using var naturalSize = Interop.Actor.GetNaturalSize(Handle).CheckException();
                return naturalSize.ToSize();
            }
        }
//...
```