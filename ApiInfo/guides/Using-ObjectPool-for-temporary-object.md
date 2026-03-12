### Background
- DALi에서는 primitive type이 아닌 다양한 class 데이터 객체를 사용
- 일반적인 상황에서는 struct를 사용하여 stack에 객체가 할당되도록 하는것이 맞지만, Native 객체에 연동되는 상황에서는 class로 표현할 수 밖에 없음
- 이러한 객체들은 heap에 할당되어 GC에 영향을 주기 때문에, 이를 최적화하기 위한 방안이 필요함

### 기존 NUI 방안
- None (Tizen.UI ObjectPool의 아이디어를 채택하여 적용 중)

### Tizen.UI 방안
- Dispose를 호출했을때 객체를 Pool에 회수함
- Dispose일때만 회수하고 Finalizer에서는 회수를 하지 않는 이유
  - 멀티 쓰레드 문제
    - GC에 의해서도 회수되도록 할 경우 pool 저장소를 Concurrent한 Collection으로 변경함
    - 하지만, 이 Collection은 (임시) 메모리 사용량이 많음
  - Unreachable문제
    - GC에 의해 회수되는 객체는 unreachable한 객체임.
    - ObjectPool 객체에 저장한 Value에 대해서도 unreachable하기 때문에, Value에 저장한 값이 이미 먼저 삭제되었을 가능성 존재
    - 이를 방지하기 위해, 사용중인 Value를 별도로 저장하기 위한 Collection을 정적으로 만들고 거기에 저장해야 함
      - 이 경우 생성시에 Pool컬랙션에서 값을 꺼내오는 과정과 사용중인 Value을 저장하기 위한 컬렉션에 값을 저장하기 위한 과정이 필요하여, 상대적으로 비효율이 발생할수 있어 적용하지 않음
- using 을 사용하여 블럭 단위로 사용하고, 해당 블럭을 빠져 나갈때 자동으로 Pool에 회수가 가능하도록 함
- implicit operator를 구현하여 기존에 T객체 타입으로 사용중이던 변수를 ObjectPool<T>로 변경해도 그대로 사용가능하도록 함

###### ObjectPool 구현
```cs
public static class ObjectPool
{
    public static ObjectPool<Vector4Handle> NewVector4()
    {
        return ObjectPool<Vector4Handle>.New() ?? new ObjectPool<Vector4Handle>(Interop.Vector4.NewVector4());
    }

    public static ObjectPool<Vector4Handle> NewVector4(float x, float y, float z, float w)
    {
        var obj = NewVector4();
        obj.Value.SetValue(x, y, z, w);
        return obj;
    }

    public static ObjectPool<Vector3Handle> NewVector3()
    {
        return ObjectPool<Vector3Handle>.New() ?? new ObjectPool<Vector3Handle>(Interop.Vector3.NewVector3());
    }

    public static ObjectPool<Vector3Handle> NewVector3(float x, float y, float z)
    {
        var obj = NewVector3();
        obj.Value.SetValue(x, y, z);
        return obj;
    }

    public static ObjectPool<Vector2Handle> NewVector2()
    {
        return ObjectPool<Vector2Handle>.New() ?? new ObjectPool<Vector2Handle>(Interop.Vector2.NewVector2());
    }

    public static ObjectPool<Vector2Handle> NewVector2(float x, float y)
    {
        var obj = NewVector2();
        obj.Value.SetValue(x, y);
        return obj;
    }
}
```

###### ObjectPool 사용 예
```cs
public class View
{
  //...
  public Size WorldScale
  {
    get
    {
        using var vector3 = ObjectPool.NewVector3();
        Interop.ActorInternal.RetrieveCurrentPropertyVector3(Handle, DaliPropertyKey.View.WorldScale, vector3);
        return new Size(Interop.Vector3.XGet(vector3), Interop.Vector3.YGet(vector3));
    }
  }
  //...
}
```