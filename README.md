# ResearchWindows
Windows アプリの開発に関する調査


# Direct2D


# ColorReductionTool


## ImageSharp を使う
1. ソリューションエクスプローラーでプロジェクトを右クリックし、「NuGet パッケージの管理」を選択
1.「参照」タブで SixLabors.ImageSharp を検索
1.「インストール」ボタンをクリック

## ImageSharp に 図形描画やパス操作をしたい
ImageSharp に 図形描画やパス操作の機能を追加するするにはSixLabors.ImageSharp.Drawing パッケージの追加が必要。

1. ツールバーのプロジェクト(P)>NuGetパッケージの管理を選択。
1. 左カラムのオンラインを選択したのち、SixLabors.ImageSharp.Drawingを入力。
1. SixLabors.ImageSharp.Drawing 2.1.6をインストール

### ColorReductionTool.csproj
```xml
  <ItemGroup>
    <PackageReference Include="SixLabors.ImageSharp" Version="3.1.10" />
    <PackageReference Include="SixLabors.ImageSharp.Drawing" Version="2.1.6" />
  </ItemGroup>
```
