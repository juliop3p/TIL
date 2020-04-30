## ESLint, Prettier and Editor Config Setup in a React project

1. Install ESLint as a DevDepencie.
   `yarn add eslint -D`

2) Init the ESLint file.
   `yarn eslint --init`

<p>Config</p>
<pre>
? How would you like to use ESLint? To check syntax, find problems, and enforce code style
? What type of modules does your project use? JavaScript modules (import/export)
? Which framework does your project use? React
? Does your project use TypeScript? No
? Where does your code run? Browser
? How would you like to define a style for your project? Use a popular style guide
? Which style guide do you want to follow? Airbnb: https://github.com/airbnb/javascript
? What format do you want your config file to be in? JavaScript
</pre>

3. Install prettier and another DevDependencies.
   `yarn add prettier eslint-config-prettier eslint-plugin-prettier babel-eslint -D`

4) eslintrc.js
<pre>
module.exports = {
  env: {
    browser: true,
    es6: true,
  },
  extends: ['plugin:react/recommended', 'airbnb', 'prettier', 'prettier/react'],
  globals: {
    Atomics: 'readonly',
    SharedArrayBuffer: 'readonly',
  },
  parser: 'babel-eslint',
  parserOptions: {
    ecmaFeatures: {
      jsx: true,
    },
    ecmaVersion: 2018,
    sourceType: 'module',
  },
  plugins: ['react', 'prettier'],
  rules: {
    'prettier/prettier': 'error',
    'react/jsx-filename-extension': ['warn', { extensions: ['.jsx', '.js'] }],
    'import/prefer-default-export': 'off',
  },
};
</pre>

5) .prettierrc
<pre>
{
  "singleQuote": true,
  "trailingComma": "es5"
}
</pre>

6) .editorconfig
<pre>
root = true

[*]
indent_style = space
indent_size = 2
end_of_line = lf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true

</pre>
