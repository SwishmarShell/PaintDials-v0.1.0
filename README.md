# PaintDIals v0.1.0

### ペイントソフトの外部ツール。

今回の初期バージョンは、ペイントソフト 【 Krita 】 の使用を、対象としています。<br>

- English version is available here: [EN_REDME.md](https://github.com/SwishmarShell/PaintDials-v0.1.0/blob/master/EN_REDME.md)
- Download
You can download the latest version from the Releases page:
[https://github.com/SwishmarShell/ASoVtetra_version0.5.1/releases/latest](https://github.com/SwishmarShell/ASoVtetra_version0.5.1/releases/latest)<br>

## Features
> ペイントソフト 【 Krita 】 との連携<br>
> JSON ファイルを経由して、連携<br>

> **不透明度と、ブラシ・サイズ のリアルタイム変更**
> - **桁数を指定可能（キメ細い設定）**
> - Ctr キー + マウス・ホイール 数値変更（誤作動の防止）<br>
> - 数値表示<br>
> - マウス操作時、色が変わる（Hover UI）<br>
>
 
## Screenshot
![](https://github.com/SwishmarShell/PaintDials-v0.1.0/blob/master/preview%200.1.0_PNG.png "起動画面")<br>

## Requirements
> Windows 10 / 11 (x64)<br>
> Paint Soft : [ Krita ]<br>
> .NET 8 (もしくは、お使いのバージョン)<br>

## Krita Plugin
> 同梱の、<br>
**” PaintDialsMonitor - USERS Document Path.py ”**<br>
( "PaintDialsMonitor - Absolute Path.py" 絶対パス指定用 )<br><br>
を、以下の手順で、読み込み。<br>
**[ Krita ]メニュー ＞ ツール＞ スクリプト ＞ スクリプター**<br>
**＞ ファイルメニュー ＞ ファイルを開く ＞ '実行'**　を押して下さい。

>  その後、ログ表示に ↓<br>
````
======================================
C:\Users\(ユーザー名)\Documents\PaintDials\Command.json
PaintDials Monitor Started
````
> と、表示されたら、本アプリと連動が開始されます。<br>

>※ Krita再起動後は、スクリプター ＞ 実行 （同じプロジェクト）で作動する。<br>（Checked: Krita version 5.3.3 ）


## Communication Format (File: Command.json )
````
{
  "Size": 25.00,
  "Opacity": 0.75
}
````
## License
> - MIT License
>

## Attention
> - 初期起動時の、Windowsセキュリティ通知は、フォルダのアクセス管理です。<br>
````
( ↓ JSONファイルの保存先フォルダ )
Documents\PaintDials
````
````
( Ex. ↓ )
Documents\PaintDials\Command.json
````
````
( 対処方法 ↓ )
Windows キー > 検索 "コントロールされたフォルダー" Enter > ブロックの履歴 > 操作 > 許可
````
## Other
> - このプログラムは、**グラデーションを描く時**に、役に立ちます。

> - 本アプリケーションの開発のきっかけは、上記のとおり、<br>
少しずつ、変化させながら描く作業を、スムーズにします。<br>

> - ※ 各ペイントソフトによっては、ブラシの種類を、プリセット保存できる機能はあります。<br>
しかし、そんなときにも、精細な設定に、役立つことでしょう。

> - イラストレーションに関わる、多くのユーザ様の感じる方向性を、助けられることに、嬉しく思います。<br>
それは、”簡単になった”　”使用している感じが、コミットしている”　などです。<br>
今回の開発も、Microsoft Copilot AI からサポートを得られ、とても良い学びをしました。<br>
