module.exports = {
  root: true,
  parser: 'babel-eslint',
  parserOptions: {
    sourceType: 'module'
  },
  // https://github.com/feross/standard/blob/master/RULES.md#javascript-standard-style
  extends: 'standard',
  // required to lint *.vue files
  plugins: [
    'html'
  ],
  // add your custom rules here
  'rules': {
    // allow paren-less arrow functions
    'arrow-parens': 0,
    // allow async-await
    'generator-star-spacing': 0,
    // allow debugger during development
    'no-debugger': process.env.NODE_ENV === 'production' ? 2 : 0,
    'no-var': ['error'],
    'no-undef': 'warn',
    'curly': ['error', 'all'],
    'keyword-spacing': ['error', { 'before': true, 'after': true }],
    'quotes': ['error', 'single', { 'avoidEscape': true }],
    'linebreak-style': ['error', 'unix'],
    'semi': ['error', 'always'],
    'indent': ['error', 2, { 'SwitchCase': 1 }],
    'object-curly-spacing': ['error', 'always'],
    'comma-dangle': ["error", "always-multiline"],
    'space-before-function-paren': ["error", "never"],
  }
}
