import TextButton from './TextButton.vue'

describe('<TextButton />', () => {
  it('renders', () => {
    // see: https://on.cypress.io/mounting-vue
    cy.mount(TextButton, { props: { fullWidth: true, variant: 'primary' }, slots: { default: 'Hello' } })
  })
  it('is clickable', () => {
    cy.mount(TextButton, { props: { fullWidth: true, variant: 'primary' }, slots: { default: 'Hello' } })
    cy.get('v-btn').click()
  })
})