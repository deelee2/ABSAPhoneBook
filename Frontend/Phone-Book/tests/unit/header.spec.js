import { shallowMount } from '@vue/test-utils'
import Header from '../../src/components/Header.vue'

describe('Header.vue', () => {
  it('renders props.msg when passed', () => {
    const search = ''
    const wrapper = shallowMount(Header, {
      propsData: { search }
    })
    expect(wrapper.text()).toMatch(search)
  })
})
