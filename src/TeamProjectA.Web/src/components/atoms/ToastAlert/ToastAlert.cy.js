import ToastAlert from './ToastAlert.vue'

describe('<ToastAlert />', () => {
  it('renders', () => {
    // see: https://on.cypress.io/mounting-vue
    cy.mount(ToastAlert, { props: { message: 'Test', variant: 'Success' } })
  })
})