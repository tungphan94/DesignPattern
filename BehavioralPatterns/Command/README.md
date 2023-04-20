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
```mermaid
classDiagram

class DocumentInvoker{
    -Command[] undoCommands
    -Command[] redoCommands
    -Document document
    +void undo()
    +void redo()
    +void write(string text)
    +string getText()
          }
class Command {
          <<interface>>
          +undo()
          +redo()        
          }
class EditCommand {
          -Doccument document
          -string text
          +void undo()
          +void redo()
          }
class Document {
        -string[] listStrs
        -void write(string text)
        -void add(string text)
        -void remove()
        -string getText()
          }
class Client {
          }          
Command  <|-- EditCommand
EditCommand *--Document
DocumentInvoker *-- Command
 Client    <|.. EditCommand
```

