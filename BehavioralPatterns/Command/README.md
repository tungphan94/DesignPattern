```mermaid
graph TD;
    自動作図プログラム-->|起動|BricsCad;
    自動作図プログラム-->|参照|自動作図中間ファイル;
    BricsCad-->|ロード|自動作図モジュール;
    自動作図モジュール-->|参照|自動作図中間ファイル;
    自動作図プログラム-->|出力|ログ;
    自動作図モジュール-->|出力|ログ;
    自動作図モジュール --> |印刷|プリンタ;
    自動作図モジュール --> |参照|自動作図システム設定ファイル;
```


# コマンド パターン
Command （コマンド、 命令） は、 振る舞いに関するデザインパターンの一つで、 リクエストを、 それに関するすべての情報を含む独立したオブジェクトに転換します。

## コマンドパターンのクラス図
```mermaid
classDiagram

class Invoke{
    -Command
    +setCommand(Command cmd)
    +Execute()
          }
class Command {
          <<interface>>
          +Execute()
          }
class ConcreteCommand {
          -Receiver
          +Execute()
          }
class Receiver {
          +action()
          }
class Client {
          }          
Command  <|-- ConcreteCommand
ConcreteCommand *--Receiver
Invoke *-- Command
 Client    <|.. ConcreteCommand
```
### コマンド の役割り
1. Command（命令） 
命令のインターフェース（API）を定義する役です。
1. 具象コマンド （ConcreteCommand）
具体的命令の役。Commandのインターフェースを実際に実装する
1. Receiver	
受信者の役。命令の受け取り手となる
1. Client	
依頼者の役。具体的命令を生成し、命令の受け取り手を割り当てる
1. Invoker	
起動者の役。Commandで定義されているインターフェースを呼び出し、命令の実行を開始する

# サンプルコードの解説
コマンド パターンの説明のため、文字列表示の機能を実装します。

```mermaid
classDiagram

class Invoker{
    -Command
    +setCommand(Command cmd)
    +Execute()
          }
class Command {
          <<interface>>
         +Execute()     
          }
class ShutdownCmd {
        +ShutdownCmd(ComputerReceiver receiver)
        +Execute()  
          }
class SleepCmd {
        +SleepCmd(ComputerReceiver receiver)
        +Execute()  
          }
class OpenCmd {
        +OpenCmd(ComputerReceiver receiver)
        +Execute()  
          }          
class ComputerReceiver {
        +ShutDown()
        +Open()
        +Sleep()
          }
class Client {
          }          
Command  <|-- ShutdownCmd
Command  <|-- OpenCmd
Command  <|-- SleepCmd
Invoker *-- Command
Client  <|.. Command
Client    <|.. ComputerReceiver
ComputerReceiver    <|.. ShutdownCmd
ComputerReceiver    <|.. OpenCmd
ComputerReceiver    <|.. SleepCmd
```

