# Changelog

## 1.0.0 (2024-12-12)


### ⚠ BREAKING CHANGES

* update to dotnet 9
* update to dotnet 9
* use `System.IO.Abstractions` to help mocking + Improve tests
* use App.cs as main program class instead of using ExampleService.cs

### Features

* add .editorconfig ([af3b0f9](https://github.com/Payadel/ConsoleSharpTemplate/commit/af3b0f94907458e285af3c0887591813c5be4ae3))
* add `AppSettings.cs` ([d8579be](https://github.com/Payadel/ConsoleSharpTemplate/commit/d8579be922fd5e598b18fc85dda915aa92451e90))
* add `EnsureInputsAreValid` method to `App` ([126c74b](https://github.com/Payadel/ConsoleSharpTemplate/commit/126c74be682f18bdc62225c388d980febd5f811a))
* add `run.sh` to run project with docker compose ([6a696bc](https://github.com/Payadel/ConsoleSharpTemplate/commit/6a696bc132e87e9bbfd551d88f7c881ad7286813))
* add command-line parser ([fd7ff3b](https://github.com/Payadel/ConsoleSharpTemplate/commit/fd7ff3b45ecc2c6d605d0b2ed1c2a4d23075e63b))
* add sqlite ([790d971](https://github.com/Payadel/ConsoleSharpTemplate/commit/790d9715309101758520490dab51bd94e2a5b7ff))
* add template for `output` parameter ([f777f39](https://github.com/Payadel/ConsoleSharpTemplate/commit/f777f39ea241908bb1d90b77451eab9b1630233f))
* add template for `output` parameter ([#10](https://github.com/Payadel/ConsoleSharpTemplate/issues/10)) ([e794227](https://github.com/Payadel/ConsoleSharpTemplate/commit/e794227e471de7eb2a1205cc06818ef92dd04336))
* add template.json ([f512e17](https://github.com/Payadel/ConsoleSharpTemplate/commit/f512e1780d44ea4b2dd75a56433a2caf422efce0))
* **ci:** add codeql.yml ([6ae046a](https://github.com/Payadel/ConsoleSharpTemplate/commit/6ae046adf43f45c4ecf3baecc94d13eee59d0fa0))
* **ci:** add codeql.yml ([400b663](https://github.com/Payadel/ConsoleSharpTemplate/commit/400b6633d2ecb537c20591c6b3feb8c8536cdf5e))
* **ci:** add dependabot.yml ([955eb26](https://github.com/Payadel/ConsoleSharpTemplate/commit/955eb26390bc714676213cc99f0145c4e34b571f))
* **ci:** add dependabot.yml ([a75f8d3](https://github.com/Payadel/ConsoleSharpTemplate/commit/a75f8d305528d0a915c30423644ca3a57575e170))
* **ci:** add dotnet.yml ([eda6db4](https://github.com/Payadel/ConsoleSharpTemplate/commit/eda6db40fdd1c46ace849a4c0928c6d37ce1dc7e))
* **ci:** add pr-coverage.yml ([d11ddb9](https://github.com/Payadel/ConsoleSharpTemplate/commit/d11ddb99ef12877a7b9c848a4851f01d4be5522e))
* **ci:** add release-please.yml ([9c0a4da](https://github.com/Payadel/ConsoleSharpTemplate/commit/9c0a4da3cc2e5a926cef9ee88d2bf8ef7a92eadf))
* **ci:** add release-please.yml ([d713fda](https://github.com/Payadel/ConsoleSharpTemplate/commit/d713fdadd74f7d3b2fd9a50f8183ade930cb86d7))
* **command-line:** add sample validation ([e137841](https://github.com/Payadel/ConsoleSharpTemplate/commit/e13784139e6c5ce3d2429af7d4aa3f1cdf80ace6))
* implement base codes ([91c29d4](https://github.com/Payadel/ConsoleSharpTemplate/commit/91c29d4f7a543cabc0bee44f058ce7077dab767d))
* **pack:** add pack data to ConsoleSharp.csproj ([9b8adeb](https://github.com/Payadel/ConsoleSharpTemplate/commit/9b8adeb9d1d0e6fe3191f693b0a9be6adbc9370d))
* **pack:** add pack data to ConsoleSharp.csproj ([8b3144e](https://github.com/Payadel/ConsoleSharpTemplate/commit/8b3144e5d782cfeca3717752d54c5b1cf8e87201))
* **scripts:** add new scripts ([b5272f8](https://github.com/Payadel/ConsoleSharpTemplate/commit/b5272f8f3a008a582482932a7a3e9e5f054001ce))
* **scripts:** add new scripts ([195b317](https://github.com/Payadel/ConsoleSharpTemplate/commit/195b3177d39f0aa8f52b58c825d9fdbba78b3720))
* **settings:** override `ToString` for `AppSettings` ([a2f7df0](https://github.com/Payadel/ConsoleSharpTemplate/commit/a2f7df032a2934234122bd48a3fb0e123f85c625))


### Bug Fixes

* [#8](https://github.com/Payadel/ConsoleSharpTemplate/issues/8) ([fb37481](https://github.com/Payadel/ConsoleSharpTemplate/commit/fb374814a3a35e6867c1bd2a9de3967790ccfcb0))
* [#8](https://github.com/Payadel/ConsoleSharpTemplate/issues/8) ([47ebe4d](https://github.com/Payadel/ConsoleSharpTemplate/commit/47ebe4d6f8e13189e498d676e50799b2e9e4a31b))
* add tests for `EnsureInputsAreValid` method ([9ad6b50](https://github.com/Payadel/ConsoleSharpTemplate/commit/9ad6b50bdc6fa48daf1a3d121a9cbbda515a127c))
* add tests for AppSettingsTests.ToString() ([5eae9fe](https://github.com/Payadel/ConsoleSharpTemplate/commit/5eae9fe84324713a520137398c2a48033edbc0a2))
* add tests for CommandLine.cs ([1af0c9f](https://github.com/Payadel/ConsoleSharpTemplate/commit/1af0c9fa47cfadfccedd5b1783f06750a0f3f220))
* **ci:** dependabot.yml ([d1ad933](https://github.com/Payadel/ConsoleSharpTemplate/commit/d1ad9333a269f704f9900a6c5f80ab3dbb73cd59))
* **ci:** dependabot.yml ([b3edc14](https://github.com/Payadel/ConsoleSharpTemplate/commit/b3edc14c7316650b20e09a2b5e0a95aae70a8875))
* **ci:** update release-please.yml ([cf2191a](https://github.com/Payadel/ConsoleSharpTemplate/commit/cf2191af70a0ce7347fe3679e66a545204c6d666))
* **database:** add database volume to docker-compose.yml ([1cedb62](https://github.com/Payadel/ConsoleSharpTemplate/commit/1cedb62892731bea4302e0358601311ed8a0893a))
* **dep:** update packages ([8a378b1](https://github.com/Payadel/ConsoleSharpTemplate/commit/8a378b19cf7dab9068de55cc71a1f17a75687e7e))
* **dep:** update packages ([57f1378](https://github.com/Payadel/ConsoleSharpTemplate/commit/57f137899c818dcb9703efdf4ad2ca28831d279a))
* **gitignore:** add `*.DotSettings.user` ([03767ee](https://github.com/Payadel/ConsoleSharpTemplate/commit/03767ee0b7e614991bcc90dd4f798a45677a319f))
* **logging:** use appsettings.json configurations ([83feab3](https://github.com/Payadel/ConsoleSharpTemplate/commit/83feab378ace484db709a7ee9c30aa01dca67dc5))
* move AppSettings.cs to `settings` folder ([a059db9](https://github.com/Payadel/ConsoleSharpTemplate/commit/a059db98234179ed0b86f821b7fb1c7755857db9))
* remove `template` from project name ([281d610](https://github.com/Payadel/ConsoleSharpTemplate/commit/281d610e6c8c247ad9f8b783a02128a6654719ab))
* **scripts:** update run.sh and move into `scripts` folder ([d892d2e](https://github.com/Payadel/ConsoleSharpTemplate/commit/d892d2e7a4c86a23f7b94b71ac2c1bdd4cc03d55))
* **scripts:** update run.sh and move into `scripts` folder ([1b0a156](https://github.com/Payadel/ConsoleSharpTemplate/commit/1b0a156e263121dbcb03d90c461c65aa6f68d49f))
* update to dotnet 9 ([fb37481](https://github.com/Payadel/ConsoleSharpTemplate/commit/fb374814a3a35e6867c1bd2a9de3967790ccfcb0)), closes [#8](https://github.com/Payadel/ConsoleSharpTemplate/issues/8)
* update to dotnet 9 ([47ebe4d](https://github.com/Payadel/ConsoleSharpTemplate/commit/47ebe4d6f8e13189e498d676e50799b2e9e4a31b)), closes [#8](https://github.com/Payadel/ConsoleSharpTemplate/issues/8)
* use `System.IO.Abstractions` to help mocking + Improve tests ([3b4bb71](https://github.com/Payadel/ConsoleSharpTemplate/commit/3b4bb718439742f04de61fb8bcfb512864899099))
* use App.cs as main program class instead of using ExampleService.cs ([954c848](https://github.com/Payadel/ConsoleSharpTemplate/commit/954c84832d00924b4fb6c3e71a1696dd0e0e8194))
