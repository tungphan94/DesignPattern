# Decorator パターン
Decorator （デコレーター、 装飾器） は、 構造に関するデザインパターンの一つで、 ある振る舞いを含む特別なラッパー・オブジェクトの中にオブジェクトを配置することで、 それらのオブジェクトに新しい振る舞いを付け加えます。

## Decorator の　役割り
```mermaid
classDiagram
Component  <|-- ConcreteComponent
Component  <|-- Decorator
Decorator  <|-- ConcreteDecoratorA
Decorator  <|-- ConcreteDecoratorB
Component : method1()
Component : method2()
ConcreteComponent : method1()
ConcreteComponent : method2()
Decorator : Component
ConcreteDecoratorA : method1()
ConcreteDecoratorA : method2()
ConcreteDecoratorB : method1()
ConcreteDecoratorB : method2()
```

1. Component(部品)
機能追加の核となるクラスです。機能拡張するメソッドのインタフェースを定義します。
2. ConcreteComponent(具体的な部品)
「Component」のインタフェースを実装します。基本となる機能を実装します。
3. Decorator(装飾者)
「Component」を実装しているオブジェクトを保持します。「Component」のインタフェースを受流し、サブクラスに実装させます。
※ 保持対象となるのは、「ConcreteComponent」「ConcreteDecoratorA・B」になります。
4. ConcreteDecoratorA・B(具体的な装飾者)
「Decorator」のインタフェースを実装します。
5. Client(依頼者)
「Decorator」パターンを適用したクラスを利用し処理します。

## Decorator パターンの仕組み
Decorator パターンの説明のため、例のテーマは「Pizza」にします。

```mermaid
classDiagram
interface_IPizza  <|-- TomatoPizza
interface_IPizza  <|-- ChickkenPizza
interface_IPizza  <|-- PizzaDecorator
interface_IPizza : +doPizza()　string
TomatoPizza : +doPizza()　string
ChickkenPizza : +doPizza()　string
PizzaDecorator: +doPizza()　string
PizzaDecorator: mPizza -- IPizza
PizzaDecorator: +PizzaDecorator(IPizza pizza)　
PizzaDecorator <|-- PepperDecorator
PizzaDecorator <|-- CheeseDecorator
PepperDecorator: +doPizza()　string
PepperDecorator: 
PepperDecorator: +addPepper() string
CheeseDecorator: +doPizza()　string
CheeseDecorator: 
CheeseDecorator: +addCheese() string
```

1. IPizza インターフェイスは、Decorator デザイン パターンのコンポーネントです。
2. TomatoPizza と ChickenPizza は IPizza の実装です (ConcreteComponent )。これらは、基本となる機能を実装します。
3. PizzaDecorator は、上記の設計図の中心です。TomatoPizza や ChickenPizza のピザの既存のインスタンスを保持します。このプロパティは ctor メソッドによって設定され、プログラムの実行中に展開されます。
4. PepperDecorator と CheeseDecorator は拡張メソッドを実装します。この例では、PepperDecorator は既存のピザにコショウを追加します。拡張機能は addPepper() メソッドに実装されています。

